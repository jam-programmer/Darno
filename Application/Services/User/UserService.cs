using Application.Common;
using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Common.Messages;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Azure.Core;
using Domain.Entities.Identity;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Text;
using System.Threading;

namespace Application.Services.User;

public class UserService : IUserService
{
    readonly RoleManager<RoleEntity> _roleManager;
    readonly UserManager<UserEntity> _userManager;
    readonly IContext _context;
    public UserService(
        IContext context,
        RoleManager<RoleEntity> roleManager,
        UserManager<UserEntity> userManager
        )
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
    }
    public async Task DeleteUserAsync(Guid UserId, CancellationToken cancellationToken)
    {
        UserEntity? user = await _userManager.FindByIdAsync(UserId.ToString());
        if (user == null)
        {
            throw new NullReferenceException(CustomMessage.NotFoundOnDb);
        }
        await _userManager.DeleteAsync(user);
    }

    public async Task<UserDto> GetUserByIdAsync(Guid UserId, CancellationToken cancellationToken)
    {
        UserEntity? user = await _userManager.FindByIdAsync(UserId.ToString());
        if (user == null)
        {
            throw new NullReferenceException(CustomMessage.NotFoundOnDb);
        }
        return user.Adapt<UserDto>();
    }

    public async Task<PaginatedList<UserViewModel>> GetUsersAsync(Pagination pagination, CancellationToken cancellationToken)
    {
        IQueryable<UserEntity> query = _userManager.Users.AsQueryable();
        PaginatedList<UserViewModel> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w => w.FullName!.Contains(pagination!.keyword)
            || w.UserName!.Contains(pagination.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<UserEntity, UserViewModel>
        (pagination.currentPage,
                pagination!.pageSize, count, total);
        return model;
    }
    public async Task UpdateUserAsync(UserDto userDto, CancellationToken cancellationToken)
    {
        StringBuilder errorMessage = new();
        IExecutionStrategy strategy = _context.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>

        {
            using (IDbContextTransaction transaction = await _context.BeginTransactionAsync())
            {
                try
                {
                    UserEntity? user = await _userManager.FindByIdAsync(userDto.Id.ToString());
                    if (user == null)
                    {
                        throw new NullReferenceException(CustomMessage.NotFoundOnDb);
                    }
                    userDto.Adapt(user);
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded is false)
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            errorMessage.AppendLine(error.Description);
                        }
                        throw new InternalException(errorMessage.ToString());
                    }
                    await DeleteRolesAsync(user);
                    await InsertRolesAsync(user, userDto.Roles!);



                    await transaction.CommitAsync();
                }
                catch (InternalException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new InternalException();
                }

            }
        });
    }
    public async Task InsertUserAsync(UserDto userDto, CancellationToken cancellationToken)
    {

        StringBuilder errorMessage = new();
        IExecutionStrategy strategy = _context.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>

        {
            using (IDbContextTransaction transaction = await _context.BeginTransactionAsync())
            {
                try
                {
                    UserEntity user = userDto.Adapt<UserEntity>();
                    IdentityResult result = await _userManager.CreateAsync(user);
                    if (result.Succeeded is false)
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            errorMessage.AppendLine(error.Description);
                        }
                        throw new InternalException(errorMessage.ToString());

                    }
                    await InsertRolesAsync(user, userDto.Roles!);

                    await transaction.CommitAsync();
                }
                catch (InternalException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new InternalException();
                }

            }
        });

    }



    async Task DeleteRolesAsync(
      UserEntity user)
    {

        IList<string> oldRoles = await _userManager.GetRolesAsync(user);
        if (!oldRoles.Any())
        {
            throw new InternalException();
        }
        IdentityResult removeOldRoles = await _userManager.RemoveFromRolesAsync(user, oldRoles);
        if (removeOldRoles.Succeeded is false)
        {
            StringBuilder errorMessage = new();

            foreach (IdentityError item in removeOldRoles.Errors)
            {
                errorMessage.AppendLine(item.Description + "/");
            }
            throw new InternalException(errorMessage.ToString());
        }
    }







    async Task InsertRolesAsync(
       UserEntity user, IReadOnlyList<string> roles)
    {
       
        IdentityResult result = await _userManager.AddToRolesAsync(user, roles);
        if (result.Succeeded == false)
        {
            StringBuilder errorMessage = new();
            foreach (IdentityError error in result.Errors)
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new InternalException(errorMessage.ToString());
        }
    }


    public async Task SetUserPasswordAsync(Guid UserId, string Password, CancellationToken cancellationToken)
    {
        UserEntity? user = await _userManager.Users
                          .FirstOrDefaultAsync(f => f.Id == UserId,
                          cancellationToken);
        if (user == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }

        bool ExistPassword = await _userManager.HasPasswordAsync(user);
        if (ExistPassword)
        {
            StringBuilder textError = new StringBuilder();
            IdentityResult resultRemoveOldUserPassword =
            await _userManager.RemovePasswordAsync(user);
            if (!resultRemoveOldUserPassword.Succeeded)
            {
                foreach (var error in resultRemoveOldUserPassword.Errors)
                {
                    textError.AppendLine(error.Description);
                }
                throw new InternalException(textError.ToString());
            }
        }

        IdentityResult insertPasswordResult =
        await _userManager.AddPasswordAsync(user, Password!);
        if (insertPasswordResult.Succeeded is false)
        {
            StringBuilder message = new();
            foreach (IdentityError item in insertPasswordResult.Errors)
            {
                message.AppendLine(item.Description + "/");
            }
            throw new InternalException(message.ToString());
        }
    }
    public async Task<Dictionary<string, string>> GetUserRolesByIdAsync(Guid userId)
    {
        IQueryable<RoleEntity> query = _roleManager.Roles.AsQueryable();
        UserEntity? user = await _userManager.Users
                          .FirstOrDefaultAsync(f => f.Id == userId);
        IList<string> roles = await _userManager.GetRolesAsync(user!);
        Dictionary<string, string> result = new();
        foreach (string role in roles)
        {
            result.Add(role, await query.Where(w => w.Name == role).Select(s => s.PersianName).FirstAsync());

        }
        return result;
    }

  

}
