using Application.DataTransferObject;
using Application.Services.Message;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Pages;

public class ContactUsModel(IMessageService messageService) : PageModel
{
    readonly IMessageService _messageService = messageService;
    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPostSendMessageAsync([FromBody] MessageModel input)
    {
        try
        {
            await _messageService.InsertMessageAsync
                (new MessageDto()
                {
                    Position=input.position,
                    CompanyName=input.companyName,
                    PhoneNumber=input.phoneNumber,
                    FullName=input.fullname,
                    Message=input.message



                });
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (Exception ex)
        {
            return new JsonResult(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
    }

}
