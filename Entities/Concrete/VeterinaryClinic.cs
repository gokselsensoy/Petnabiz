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
    public string City { get; set; }
    public string District { get; set; }

    //vergi no

    public ICollection<Vet> Vets { get; set; } = new List<Vet>();
    public ICollection<PetOwner> PetOwners { get; set; } = new List<PetOwner>();
}
