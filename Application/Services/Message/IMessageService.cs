using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Message;

public interface IMessageService
{
    Task InsertMessageAsync(MessageDto message);
    Task<PaginatedList<MessageViewModel>> GetMessagesAsync(Pagination pagination);
    Task DeleteMessageAsync(Guid MessageId);
}
