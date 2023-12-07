using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class PetOwner : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public int ClinicId { get; set; }
    public VeterinaryClinic? VeterinaryClinic { get; set; } = null!;

    public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    public ICollection<Examination> Examinations { get; set; } = new List<Examination>();
}
