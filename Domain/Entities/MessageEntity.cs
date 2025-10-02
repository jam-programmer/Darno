using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class MessageEntity : BaseEntity, IDelete
{
    public string? FullName {  get; set; }
    public string? PhoneNumber {  get; set; }
    public string? CompanyName {  get; set; }
    public string? Position {  get; set; }
    public string? Message {  get; set; }
    public bool IsDelete { get ; set ; }=false;
}
