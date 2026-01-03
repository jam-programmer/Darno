using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SliderEntity : BaseEntity
    {
        public string ImagePath { get; set; }
        public DateTime StartShow { get; set; }
        public DateTime EndShow { get; set; }
        public string Link { get; set; }
    }
}
