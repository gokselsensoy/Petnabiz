using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class VeterinaryClinic : IEntity
{
    public int Id { get; set; }
    public string ClinicName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public City? City { get; set; } = null!;
    public District? District { get; set; } = null!;

    //vergi no

    public ICollection<Vet> Vets { get; set; } = new List<Vet>();
    public ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<Examination> Examinations { get; set; } = new List<Examination>();
}
