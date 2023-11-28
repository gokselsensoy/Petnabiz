using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Patient : IEntity
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public string Animal { get; set; }
    public string Breed { get; set; }
    public string Gender { get; set; }

    public int VetId { get; set; }
    public Vet Vet { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
