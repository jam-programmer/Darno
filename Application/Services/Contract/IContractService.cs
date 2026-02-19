using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contract
{
    public interface IContractService
    {
        Task<Guid> CreateContract(ContractDto dto);
        Task UpdateContract(ContractDto contract);
        Task DeleteContract(Guid contractId);
        Task<ContractDto> GetContract(Guid contractId);


    }
}
