using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.AppUserDtos
{
    public class AppUserInfoDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
    }
}
