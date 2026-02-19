using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record CommitmentDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "مفاد قرارداد الزامی است")]
        [MaxLength(1000, ErrorMessage = "متن نباید بیشتر از 1000 کاراکتر باشد")]
        public string Text { get; set; }
        public CommitmentType CommitmentType { get; set; }
    }
}
