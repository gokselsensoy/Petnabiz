using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IExaminationDal : IEntityRepository<Examination>
    {
        List<ExaminationDetailDto> GetExaminationDetails(int userId);
        List<PetExaminationDetailDto> GetPetExaminationDetails(int petId);
        List<PastExaminationDetailDto> GetPastExaminationDetails(int clinicId);
    }
}
