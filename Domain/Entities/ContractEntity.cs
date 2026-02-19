using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class ContractEntity : BaseEntity
    {
        public string? ContractNumber { get; set; }
        public string? Subject { get; set; }
        public string? EmployerName { get; set; }
        public int EmployerId { get; set; }
        public string? ContractorName { get; set; }
        public int ContractorId { get; set; }
        public ContractType Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }


        public List<ContractMapCommitment> ContractCommitments { get; set; } = new();

    }
}
