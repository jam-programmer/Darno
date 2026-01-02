using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Slider;

public interface ISliderService
{
    Task<IReadOnlyList<SliderViewModel>> GetActiveSlidersAsync();
    Task InsertSliderAsync(SliderDto Slider);
    Task UpdateSliderAsync(SliderDto Slider);
    Task<SliderDto> GetSliderByIdAsync(Guid SliderId);
    Task DeleteSliderAsync(Guid SliderId);
    Task<PaginatedList<SliderViewModel>> GetSlidersAsync(Pagination pagination);

}
