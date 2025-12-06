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
    Task SignInAsync(SignInDto signIn,CancellationToken cancellationToken=default);
<<<<<<< HEAD

    Task SaveUserInformation(UserInformationDto dto);
=======
    Task SaveUserInformation(UserInformationDto dto);

>>>>>>> ca465ceb95eddb03965830ce5a3f6cd36ba66f94

}
