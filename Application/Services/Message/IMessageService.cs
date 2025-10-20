using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Message;

public interface IMessageService
{
    Task InsertMessageAsync(MessageDto message);

}
