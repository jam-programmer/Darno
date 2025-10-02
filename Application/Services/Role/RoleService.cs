using Application.Common;
using Application.Common.Extension;
using Application.Common.Messages;
using Application.DataTransferObject;
using Application.ViewModels;
using Azure.Core;
using Domain.Entities.Identity;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Role;

public class RoleService : IRoleService
{
    readonly RoleManager<RoleEntity> _roleManager;
    public RoleService(RoleManager<RoleEntity> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task DeleteRoleAsync(Guid roleId)
    {
        RoleEntity? roleEntity = await _roleManager.FindByIdAsync(roleId.ToString());
        if (roleEntity == null)
        {
            throw new NullReferenceException(CustomMessage.NotFoundOnDb);
        }
        await _roleManager.DeleteAsync(roleEntity);
    }

    public async Task<PaginatedList<RoleViewModel>> GetRolesAsync(Pagination pagination)
    {
        IQueryable<RoleEntity> query = _roleManager.Roles.AsQueryable();

        PaginatedList<RoleViewModel> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w => w.PersianName!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize); 
        int total = query.Count();

        model = await query.MappingedAsync<RoleEntity, RoleViewModel>
        (pagination.currentPage,
                pagination!.pageSize, count, total);
        return model;
    }

    public async Task<RoleDto> GetRoleByIdAsync(Guid roleId)
    {
        RoleEntity? roleEntity = await _roleManager.FindByIdAsync(roleId.ToString());
        if (roleEntity == null)
        {
            throw new NullReferenceException(CustomMessage.NotFoundOnDb);
        }
        return roleEntity.Adapt<RoleDto>();
    }

    public async Task InsertRoleAsync(RoleDto role)
    {
        RoleEntity roleEntity = new()
        {
            PersianName = role.PersianName!,
            Name = role.Name,
        };
        await _roleManager.CreateAsync(roleEntity);
    }

    public async Task UpdateRoleAsync(RoleDto role)
    {
        RoleEntity? roleEntity = await _roleManager
            .FindByIdAsync(role.Id.ToString());

        if (roleEntity == null)
        {
            throw new NullReferenceException(CustomMessage.NotFoundOnDb);
        }
        roleEntity.Name = role.Name;
        roleEntity.PersianName = role.PersianName!;
        await _roleManager.UpdateAsync(roleEntity);
    }

    public async Task<Dictionary<string, string>> GetRolesAsync(string role)
    {
        IQueryable<RoleEntity> query = _roleManager.Roles.AsQueryable();

        if (!string.IsNullOrEmpty(role))
        {
            query = query.Where(r => r.PersianName.Contains(role));
        }

        Dictionary<string, string> result = await query.ToDictionaryAsync
            (r => r.Name!, r => r.PersianName!);

        return result;
    }

}
