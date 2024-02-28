using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AppointmentDetailDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PetName { get; set; }
        public string PetSpecies { get; set; }
        public string PetBreed { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
