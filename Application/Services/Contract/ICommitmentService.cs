using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contract
{
    public interface ICommitmentService
    {
        Task<Guid> CreateCommitment(CommitmentDto dto);
        Task UpdateCommitment(CommitmentDto commitment);
        Task DeleteCommitment(Guid commitmentId);
        Task<CommitmentDto> GetCommitment(Guid commitmentId);
    }
}
