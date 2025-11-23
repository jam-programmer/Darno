using Application.Common;
using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Common.Messages;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Message;

public class MessageService : IMessageService
{
    readonly IContext _context;
    public MessageService(IContext context)
    {
        _context = context;
    }

    public async Task DeleteMessageAsync(Guid MessageId)
    {
        MessageEntity? entity =
            await _context.Entity<MessageEntity>()
            .FirstOrDefaultAsync(f => f.Id == MessageId);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        entity.IsDelete = true;
        _context.Entity<MessageEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<PaginatedList<MessageViewModel>> GetMessagesAsync(Pagination pagination)
    {

       


        IQueryable<MessageEntity> query = _context.GetQueryable<MessageEntity>();

        PaginatedList<MessageViewModel> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w => w.FullName!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();

        model = await query.MappingedAsync<MessageEntity, MessageViewModel>
        (pagination.currentPage,
                pagination!.pageSize, count, total);
        return model;
    }

    public async Task InsertMessageAsync(MessageDto message)
    {
        MessageEntity entity=message.Adapt<MessageEntity>();
        await _context.Entity<MessageEntity>().AddAsync(entity);    
        await _context.SaveChangesAsync();
    }

   
}
