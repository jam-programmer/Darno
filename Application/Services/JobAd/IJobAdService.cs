using System;
using Application.Common;
using Application.DataTransferObject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.Services.JobAd
{
    public interface IJobAdService
    {
        Task <IReadOnlyList<JobAdViewModel>>GetActiveJobAdsAsync();
        Task InsertJobAdAsync(JobAdDto dto);
        Task UpdateJobAdAsync(JobAdDto dto);
        Task DeleteJobAdAsync(Guid jobId);
        Task<JobAdDto> GetJobAdDtoAsync(Guid jobId);
        Task<PaginatedList<JobAdViewModel>> GetJobAdsAsync(Pagination pagination);

    }
}


//Task GetJobAdByIdAsync(Guid dto);
