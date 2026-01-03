using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
   public sealed record PlanFeatureDto
    {
        public Guid Id { get; set; }
        public Guid PricingPlanId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
