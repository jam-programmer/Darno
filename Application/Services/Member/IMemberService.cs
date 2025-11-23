using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;

namespace Application.Services.Member;

public interface IMemberService
{
    Task InsertMemberAsync(MemberDto Member);
    Task UpdateMemberAsync(MemberDto Member);
    Task<MemberDto> GetMemberByIdAsync(Guid MemberId);
    Task DeleteMemberAsync(Guid MemberId);
    Task<PaginatedList<MemberViewModel>> GetMembersAsync(Pagination pagination);
    Task<IReadOnlyList<MemberForMainPageViewModel>>
        GetMembersForMainPageAsync();
}
