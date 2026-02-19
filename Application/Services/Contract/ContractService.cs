using Application.Common.CustomException;
using Application.Common.Messages;
using Application.Contract;
using Application.DataTransferObject;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contract
{
    internal class ContractService:IContractService
    {
        readonly IContext _context;
        public ContractService(IContext context)
        {
            _context = context;
        }


        public async Task<Guid> CreateContract(ContractDto contract)
        {
            var entity = new ContractEntity
            {
                ContractNumber = contract.ContractNumber,
                Subject = contract.Subject,
                EmployerName = contract.EmployerName,
                EmployerId = contract.EmployerId,
                ContractorName = contract.ContractorName,
                ContractorId = contract.ContractorId,
                Status = ContractType.PendingEmployerSignature,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                CreatedAt = DateTime.UtcNow,
            };
            await _context.Entity<ContractEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateContract(ContractDto contract)
        {
            ContractEntity entity = await _context.Entity<ContractEntity>()
             .FirstOrDefaultAsync(c => c.Id == contract.Id);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }

            if (entity.Status == ContractType.Signed)
                throw new Exception("این قرارداد امضا شده است و قابل ویرایش نمیباشد.");

           
            entity.ContractNumber = contract.ContractNumber;
            entity.Subject = contract.Subject;
            entity.EmployerName = contract.EmployerName;
            entity.EmployerId = contract.EmployerId;
            entity.ContractorName = contract.ContractorName;
            entity.ContractorId = contract.ContractorId;
            entity.Status = contract.Status;
            entity.StartDate = contract.StartDate;
            entity.EndDate = contract.EndDate;
         

            await _context.SaveChangesAsync();


        }



        public async Task DeleteContract(Guid contractId)
        {
            ContractEntity? entity =
           await _context.Entity<ContractEntity>()
           .FirstOrDefaultAsync(c => c.Id == contractId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            _context.Entity<ContractEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<ContractDto> GetContract(Guid contractId)
        {
            ContractEntity? entity =
       await _context.Entity<ContractEntity>()
       .FirstOrDefaultAsync(c => c.Id == contractId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            TypeAdapterConfig config = new();
            config.NewConfig<ContractEntity, ContractDto>()
                .Map(c => c.Id, c => c.Id)
                .Map(c => c.ContractNumber, c => c.ContractNumber)
                .Map(c => c.Subject, c => c.Subject)
                .Map(c => c.EmployerName, c => c.EmployerName)
                .Map(c => c.EmployerId, c => c.EmployerId)
                .Map(c => c.ContractorName, c => c.ContractorName)
                .Map(c => c.ContractorId, c => c.ContractorId)
                .Map(c => c.Status, c => c.Status)
                .Map(c => c.StartDate, c => c.StartDate)
                .Map(c => c.EndDate, c => c.EndDate)
             
                .Compile();


            return entity.Adapt<ContractDto>(config);
        }

    }
}

