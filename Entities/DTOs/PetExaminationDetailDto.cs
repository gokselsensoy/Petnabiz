using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PetExaminationDetailDto
    {
        public DateTime ExaminationDate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string ClinicName { get; set; }
        public string VetName { get; set; }
        public string Description { get; set; }
    }
}
