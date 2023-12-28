using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.AppUserDtos
{
    public class AppUserClinicDto : IDto
    {
        public string ClinicName { get; set; }
    }
}
