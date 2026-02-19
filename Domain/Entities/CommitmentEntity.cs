using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CommitmentEntity :BaseEntity
    {
        public string Text { get; set; }
        public CommitmentType CommitmentType { get; set; }


        public List<ContractMapCommitment> ContractCommitments { get; set; } = new();

    }
}
