using Application.Contract;
using Application.DataTransferObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;
using Application.Common.Extension;

namespace Application.Services.Slider
{
    public  class SliderService : ISliderService
    {

        readonly IContext _context;
        public SliderService(IContext context)
        {
            _context = context;
        }

        public async Task<List<SliderDto>> GetActiveSliders()
        {
            var now = DateTime.Now;

            return await _context.GetQueryable<SliderEntity>()
                .Where (S =>S.StartShow <= now && S.EndShow >= now)
                .Select (S => new SliderDto
                {
                    ImagePath = S.ImagePath,
                    Link = S.Link,
                    StartShow = S.StartShow.PersianDateWithTime(),
                    EndShow = S.EndShow.PersianDateWithTime(),
                })
                .ToListAsync();


        }
    }
}
