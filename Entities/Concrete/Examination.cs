using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Examination : IEntity
{
    public int Id { get; set; }
    public DateTime ExaminationDate { get; set; }
    public string Description { get; set; }

    public int AppointmentId { get; set; }
    public int PetId { get; set; }
    public int AppUserId { get; set; }
    public int VetId { get; set; }
    public int VeterinaryClinicId { get; set; }

    public Appointment? Appointment { get; set; } = null;
    public Pet? Pet { get; set; } = null;
    public AppUser? Appuser { get; set; }  = null;
    public Vet? Vet { get; set; } = null!;
    public VeterinaryClinic? VeterinaryClinic { get; set; } = null!;

}
