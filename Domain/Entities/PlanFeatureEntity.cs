using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PlanFeatureEntity :BaseEntity
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public Guid PricingPlanId { get; set; }
        public PricingPlanEntity? PricingPlan { get; set; }
    }
}

