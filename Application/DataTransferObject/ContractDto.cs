using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record  ContractDto
    {
        public Guid Id { set; get; }
        [Required(ErrorMessage = "نام قرارداد الزامی است")]
        public string? ContractNumber { get; set; }
        [Required(ErrorMessage = "موضوع قرارداد الزامی است")]
        public string? Subject { get; set; }
        [Required(ErrorMessage = "نام کارفرما الزامی است")]
        public string? EmployerName { get; set; }
        [Required(ErrorMessage = "کد ملی الزامی است")]
        public int EmployerId { get; set; }
        [Required(ErrorMessage = "نام مشتری الزامی است")]
        public string? ContractorName { get; set; }
        [Required(ErrorMessage = "کد ملی مشتری الزامی است")]
        public int ContractorId { get; set; }
        [Required(ErrorMessage = "درج وضعیت الزامی است")]
        public ContractType Status { get; set; }
        [Required(ErrorMessage = "تاریخ شروع قرارداد الزامی است")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "تاریخ پایان قرارداد الزامی است")]
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Guid> CommitmentIds { get; set; } = new();

    }
}
