using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PlanFeatureEntity :BaseEntity, IDelete
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public Guid PricingPlanId { get; set; }
        public PricingPlanEntity? PricingPlan { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}

