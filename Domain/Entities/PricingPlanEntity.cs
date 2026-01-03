using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PricingPlanEntity : BaseEntity,IDelete
    { 
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
      

        public ICollection<PlanFeatureEntity>? Features { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}

