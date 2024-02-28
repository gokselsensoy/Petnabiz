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

public class EfExaminationDal : EfEntityRepositoryBase<Examination, PetnabizDatabaseContext>, IExaminationDal
{
    public List<ExaminationDetailDto> GetExaminationDetails(int userId)
    {
        using (PetnabizDatabaseContext context = new PetnabizDatabaseContext())
        {
            var result = from e in context.Examinations
                         join p in context.Pets
                         on e.PetId equals p.Id
                         join v in context.Vets
                         on e.VetId equals v.Id
                         join a in context.Users
                         on e.AppUserId equals a.Id
                         where a.Id == userId
                         select new ExaminationDetailDto
                         {
                             PetName = p.Name,
                             VetName = v.FirstName + ' ' + v.LastName,
                             Description = e.Description,
                             ExaminationDate = e.ExaminationDate
                             
                             
                         };
            return result.ToList();
        }
    }
    public List<PetExaminationDetailDto> GetPetExaminationDetails(int petId)
    {
        using (PetnabizDatabaseContext context = new PetnabizDatabaseContext())
        {
            var result = from e in context.Examinations
                         join p in context.Pets
                         on e.PetId equals p.Id
                         join v in context.Vets
                         on e.VetId equals v.Id
                         join u in context.Users
                         on e.AppUserId equals u.Id
                         join vc in context.VeterinaryClinics
                         on e.VeterinaryClinicId equals vc.Id
                         join c in context.Cities
                         on vc.CityId equals c.Id
                         join d in context.Districts
                         on vc.DistrictId equals d.Id
                         where p.Id == petId
                         select new PetExaminationDetailDto
                         {
                             ClinicName = vc.ClinicName,
                             VetName = v.FirstName + ' ' + v.LastName,
                             Description = e.Description,
                             ExaminationDate = e.ExaminationDate,
                             City = c.Name,
                             District = d.Name
                         };
            return result.ToList();
        }
    }

    public List<PastExaminationDetailDto> GetPastExaminationDetails(int clinicId)
    {
        using (PetnabizDatabaseContext context = new PetnabizDatabaseContext())
        {
            var result = from e in context.Examinations
                         join p in context.Pets
                         on e.PetId equals p.Id
                         join v in context.Vets
                         on e.VetId equals v.Id
                         join u in context.Users
                         on e.AppUserId equals u.Id
                         join vc in context.VeterinaryClinics
                         on e.VeterinaryClinicId equals vc.Id
                         where vc.Id == clinicId
                         select new PastExaminationDetailDto
                         {
                             UserName = u.Name + ' ' + u.Surname,
                             PetName = p.Name,
                             PetSpecies = p.Species,
                             PetBreed = p.Breed,
                             PetGender = p.Gender,
                             VetName = v.FirstName + ' ' + v.LastName,
                             Description = e.Description,
                             ExaminationDate = e.ExaminationDate
                         };
            return result.ToList();
        }
    }
}
