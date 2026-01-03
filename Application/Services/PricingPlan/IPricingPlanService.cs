using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PricingPlan
{
    public interface IPricingPlanService
    {
        Task InsertPricingPlanAsync(PricingPlanDto pricingPlan);
        Task UpdatePricingPlanAsync(PricingPlanDto pricingPlan);
        Task<PricingPlanDto> GetPricingPlanByIdAsync(Guid PricingPlanId);
        Task DeletePricingPlanAsync(Guid PricingPlanId);
        Task<PaginatedList<PricingPlanViewModel>> GetPricingPlanAsync(Pagination pagination);
    }
}
