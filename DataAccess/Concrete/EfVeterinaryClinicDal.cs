using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete;

public class EfVeterinaryClinicDal : EfEntityRepositoryBase<VeterinaryClinic, PetnabizDatabaseContext>, IVeterinaryClinicDal
{
    public ClinicDetailDto GetClinicDetails(int clinicId)
    {
        using (PetnabizDatabaseContext context = new PetnabizDatabaseContext())
        {
            var result = from v in context.VeterinaryClinics
                         join c in context.Cities
                         on v.CityId equals c.Id
                         join d in context.Districts
                         on v.DistrictId equals d.Id
                         where v.Id == clinicId
                         select new ClinicDetailDto
                         {
                             ClinicName = v.ClinicName,
                             City = c.Name,
                             District = d.Name,
                             Email = v.Email


                         };
            return result.FirstOrDefault();
        }
    }
}
