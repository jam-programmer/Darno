using Application.Common;
using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Common.Messages;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PricingPlan
{
    public class PricingPlanService : IPricingPlanService
    {
        readonly IContext _context;
        public PricingPlanService(IContext context)
        {
            _context = context;

        }
        public async Task InsertPricingPlanAsync(PricingPlanDto pricingPlan)
        {
            PricingPlanEntity entity = pricingPlan.Adapt<PricingPlanEntity>();

            await _context.Entity<PricingPlanEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }
        public async Task UpdatePricingPlanAsync(PricingPlanDto pricingPlan)
        {
            PricingPlanEntity? entity =
         await _context.Entity<PricingPlanEntity>()
        .FirstOrDefaultAsync(f => f.Id == pricingPlan.Id);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            pricingPlan.Adapt(entity);
            _context.Entity<PricingPlanEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<PricingPlanDto> GetPricingPlanByIdAsync(Guid PricingPlanId)
        {
            PricingPlanEntity? entity =
            await _context.Entity<PricingPlanEntity>()
            .FirstOrDefaultAsync(p => p.Id == PricingPlanId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            return entity.Adapt<PricingPlanDto>();
        }
        public async Task DeletePricingPlanAsync(Guid PricingPlanId)
        {
            PricingPlanEntity? entity =
            await _context.Entity<PricingPlanEntity>()
            .FirstOrDefaultAsync(f => f.Id == PricingPlanId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            entity.IsDelete = true;
            _context.Entity<PricingPlanEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<PricingPlanViewModel>> GetPricingPlanAsync(Pagination pagination)
        {
            IQueryable<PricingPlanEntity> query = _context.GetQueryable<PricingPlanEntity>();

            PaginatedList<PricingPlanViewModel> model = new();
            if (!string.IsNullOrEmpty(pagination!.keyword))
            {
                query = query.Where(w => w.Name!.Contains(pagination!.keyword));
            }
            int count = query.Count().PageCount(pagination!.pageSize);
            int total = query.Count();

            model = await query.MappingedAsync<PricingPlanEntity, PricingPlanViewModel>
            (pagination.currentPage,
                    pagination!.pageSize, count, total);
            return model;
        }
        

    }
}
