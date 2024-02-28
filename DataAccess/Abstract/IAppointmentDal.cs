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
    public interface IAppointmentDal : IEntityRepository<Appointment>
    {
        public List<DateTime> GetAvailableAppointments(int clinicId, DateTime selectedDate);
        bool IsAppointmentAvailable(int clinicId, DateTime selectedDate);
        List<AppointmentDetailDto> GetAppointmentDetails(int clinicId);
    }
}
