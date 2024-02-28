using Core.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime AppointmentDate { get; set; }

        public List<Examination> Examinations { get; set; } = new List<Examination>();

        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; } = null!;
        public int PetId { get; set; }
        public Pet? Pet { get; set; } = null!;
        public int VeterinaryClinicId { get; set; }
        public VeterinaryClinic? VeterinaryClinic { get; set; } = null!;
    }
}
