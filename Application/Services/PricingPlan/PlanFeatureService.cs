using Application.Common.CustomException;
using Application.Common.Messages;
using Application.Contract;
using Application.DataTransferObject;
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
    public class PlanFeatureService : IPlanFeatureService
    {
        readonly IContext _context;
        public PlanFeatureService(IContext context)
        {
            _context = context;

        }
        public async Task InsertPlanFeatureAsync(PlanFeatureDto planFeature)
        {
            PlanFeatureEntity entity = planFeature.Adapt<PlanFeatureEntity>();

            await _context.Entity<PlanFeatureEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }
        public async Task UpdatePlanFeatureAsync(PlanFeatureDto planFeature)
        {
            PlanFeatureEntity? entity =
         await _context.Entity<PlanFeatureEntity>()
        .FirstOrDefaultAsync(f => f.Id == planFeature.Id);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            planFeature.Adapt(entity);
            _context.Entity<PlanFeatureEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<PlanFeatureDto> GetPlanFeatureByIdAsync(Guid PlanFeatureId)
        {
            PlanFeatureEntity? entity =
        await _context.Entity<PlanFeatureEntity>()
        .FirstOrDefaultAsync(f => f.Id == PlanFeatureId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            return entity.Adapt<PlanFeatureDto>();
        }
        public async Task DeletePlanFeatureAsync(Guid PlanFeatureId)
        {
            PlanFeatureEntity? entity =
            await _context.Entity<PlanFeatureEntity>()
            .FirstOrDefaultAsync(f => f.Id == PlanFeatureId);

            if (entity == null)  
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            entity.IsDelete = true;
            _context.Entity<PlanFeatureEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
