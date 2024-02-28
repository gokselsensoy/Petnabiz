using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ExaminationDetailDto : IDto
    {
        public string PetName { get; set; }
        public string VetName { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string Description { get; set; }

    }
}
