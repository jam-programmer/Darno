using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Role;

public interface IRoleService
{
    Task InsertRoleAsync(RoleDto role);
    Task UpdateRoleAsync(RoleDto role);
    Task<RoleDto> GetRoleByIdAsync(Guid roleId);
    Task DeleteRoleAsync(Guid roleId);
    Task<PaginatedList<RoleViewModel>> GetRolesAsync(Pagination pagination);
    Task<Dictionary<string, string>> GetRolesAsync(string role);
}
