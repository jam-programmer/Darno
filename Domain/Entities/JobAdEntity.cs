using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JobAdEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? JobTitle { get; set; }
        public string? JobCity { get; set; }
        public string? JobRole { get; set; }
        public WorkType EmploymentType { get; set; }
        public DateTime PostedDate { get; set; }
        public string? Description { get; set; }
        public bool IsDelete { get; set; } = false;






    }

}
