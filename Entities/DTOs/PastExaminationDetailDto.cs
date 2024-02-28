using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PastExaminationDetailDto : IDto
    {
        public string UserName { get; set; }
        public string PetName { get; set; }
        public string PetSpecies { get; set; }
        public string PetBreed { get; set; }
        public string PetGender { get; set; }
        public string Description { get; set; }
        public string VetName { get; set; }
        public DateTime ExaminationDate { get; set; }
    }
}
