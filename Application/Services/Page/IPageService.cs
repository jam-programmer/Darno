using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Page
{
    public interface IPageService
    {

        Task CreateAsync(PageDto dto);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id , PageDto dto);
        Task<PageDto> ReadAsync(Guid id);
    }

}
