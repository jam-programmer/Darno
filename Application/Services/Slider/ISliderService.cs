using Application.DataTransferObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Slider
{
    public interface ISliderService
    {
        Task<List<SliderDto>> GetActiveSliders();
    }
}
