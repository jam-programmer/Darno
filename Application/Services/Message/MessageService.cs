using Application.Contract;
using Application.DataTransferObject;
using Domain.Entities;
using Mapster;
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
    public async Task InsertMessageAsync(MessageDto message)
    {
        MessageEntity entity=message.Adapt<MessageEntity>();
        await _context.Entity<MessageEntity>().AddAsync(entity);    
        await _context.SaveChangesAsync();
    }
}
