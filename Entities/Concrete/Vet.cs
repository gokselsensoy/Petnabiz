using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Vet : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }

    //vet oda no

    public int VeterinaryClinicId { get; set; }
    public VeterinaryClinic? VeterinaryClinic { get; set; } = null!;

    public ICollection<Examination> Examinations { get; set; } = new List<Examination>();
}
