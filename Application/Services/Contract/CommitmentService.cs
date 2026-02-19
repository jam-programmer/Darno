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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Services.Contract
{
    internal class CommitmentService :ICommitmentService
    {
        readonly IContext _context;
        public CommitmentService(IContext context)
        {
            _context = context;
        }


        public async Task<Guid> CreateCommitment(CommitmentDto commitment)
        {
            var entity = new CommitmentEntity
            {
                Text = commitment.Text,
                CommitmentType = commitment.CommitmentType,
                
            };
            await _context.Entity<CommitmentEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateCommitment(CommitmentDto commitment)
        {
            CommitmentEntity entity = await _context.Entity<CommitmentEntity>()
             .FirstOrDefaultAsync(c => c.Id == commitment.Id);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }


            entity.Text = commitment.Text;
            entity.CommitmentType = commitment.CommitmentType;
         
            await _context.SaveChangesAsync();

        }



        public async Task DeleteCommitment(Guid commitmentId)
        {
            CommitmentEntity? entity =
           await _context.Entity<CommitmentEntity>()
           .FirstOrDefaultAsync(c => c.Id == commitmentId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            _context.Entity<CommitmentEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<CommitmentDto> GetCommitment(Guid commitmentId)
        {
            CommitmentEntity? entity =
       await _context.Entity<CommitmentEntity>()
       .FirstOrDefaultAsync(c => c.Id == commitmentId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            TypeAdapterConfig config = new();
            config.NewConfig<CommitmentEntity, CommitmentDto>()
                .Map(c => c.Id, c => c.Id)
                .Map(c => c.Text, c => c.Text)
                .Map(c => c.CommitmentType, c => c.CommitmentType)
                

                .Compile();


            return entity.Adapt<CommitmentDto>(config);
        }

    }
}
