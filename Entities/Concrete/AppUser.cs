using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public string TCID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ConfirmCode { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
        public List<Examination> Examinations { get; set; } = new List<Examination>();

        public int ClinicId { get; set; }
        public VeterinaryClinic? VeterinaryClinic { get; set; } = null!;

    }
}
