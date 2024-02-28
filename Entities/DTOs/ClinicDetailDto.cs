using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ClinicDetailDto : IDto
    {
        public string ClinicName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Email { get; set; }
    }
}
