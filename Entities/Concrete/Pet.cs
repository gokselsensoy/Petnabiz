using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Pet : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string Breed { get; set; }
    public string Gender { get; set; }

    //passport no chip no

    public int OwnerId { get; set; }
    public PetOwner? PetOwner { get; set; } = null!;

    public ICollection<Examination> Examinations { get; set; } = new List<Examination>();
}
