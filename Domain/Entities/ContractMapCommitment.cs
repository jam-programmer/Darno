using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContractMapCommitment : BaseEntity
    {
        public int CommitmentId { get; set; }
        public int ContractId { get; set; }

        public virtual ContractEntity Contract { get; set; }
        public virtual CommitmentEntity Commitment { get; set; }

    }
}
