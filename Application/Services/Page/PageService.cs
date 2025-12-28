using System;
using Application.Contract;
using Application.DataTransferObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Page
{
    public class PageService :IPageService
    {
        readonly IContext _context;
        public PageService(IContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(PageDto dto)
        {
            var page = new PageEntity
            {
                Name = dto.Name!,
                Description = dto.Description!,
                UniqueName = dto.UniqueName!

            };
            await _context.Entity<PageEntity>().AddAsync(page);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(Guid id)
        {
            var page = await _context.Entity<PageEntity>().FindAsync(id);
            if (page == null) 
                return;
            _context.Entity<PageEntity>().Remove(page);
            await _context.SaveChangesAsync();
        }



        public async Task UpdateAsync(Guid id ,PageDto dto)
        {
            var page = await _context.Entity<PageEntity>().FindAsync(id);
            if (page == null)
                return;
            {
                page.Name = dto.Name!;
                page.Description = dto.Description!;
                page.UniqueName = dto.UniqueName!;
                await _context.SaveChangesAsync();

            }
        }


        public async Task <PageDto>ReadAsync(Guid id)
        {
            var page = await _context.Entity<PageEntity>().FindAsync(id);
            if (page == null)
                return null!;

            return new PageDto
            {
                Name = page.Name,
                Description = page.Description,
                UniqueName = page.UniqueName
            };
       
        }
    }
}
