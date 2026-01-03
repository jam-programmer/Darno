using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Club
{
    public interface IClubService
    {
        Task InsertClubAsync(ClubDto club);
        Task<ClubDto> GetClubByIdAsync(Guid ClubId);
        Task<PaginatedList<ClubViewModel>> GetEmailsAsync(Pagination pagination);

    }
}
