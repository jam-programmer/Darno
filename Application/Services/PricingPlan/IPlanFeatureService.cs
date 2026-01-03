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
    public interface IPlanFeatureService
    {
        Task InsertPlanFeatureAsync(PlanFeatureDto planFeature);
        Task UpdatePlanFeatureAsync(PlanFeatureDto planFeature);
        Task<PlanFeatureDto> GetPlanFeatureByIdAsync(Guid PlanFeatureId);
        Task DeletePlanFeatureAsync(Guid PlanFeatureId);
    }
}
