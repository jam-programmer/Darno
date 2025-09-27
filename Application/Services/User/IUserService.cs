using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;

namespace Application.Services.User;

public interface IUserService
{

    Task InsertUserAsync(UserDto userDto,CancellationToken cancellationToken);
    Task UpdateUserAsync(UserDto userDto,CancellationToken cancellationToken);
    Task DeleteUserAsync(Guid UserId, CancellationToken cancellationToken);
    Task SetUserPasswordAsync(Guid UserId,string Password,CancellationToken cancellationToken);
    Task<UserDto> GetUserByIdAsync(Guid UserId, CancellationToken cancellationToken);
    Task<PaginatedList<UserViewModel>> GetUsersAsync(Pagination pagination,CancellationToken cancellationToken);
    Task<Dictionary<string, string>> GetUserRolesByIdAsync(Guid userId);

}
