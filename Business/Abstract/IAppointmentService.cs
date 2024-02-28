using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppointmentService
    {
        IDataResult<List<Appointment>> GetAll();
        bool IsAppointmentAvailable(int clinicId, DateTime selectedDate);
        IDataResult<List<DateTime>> GetAvailableAppointments(int clinicId, DateTime selectedDate);
        IDataResult<List<AppointmentDetailDto>> GetAppointmentDetails(int clinicId);
        IDataResult<Appointment> GetById(int appointmentId);
        IDataResult<List<Appointment>> GetByPetId(int petId);
        IDataResult<List<Appointment>> GetByUserId(int userId);
        IDataResult<List<Appointment>> GetByClinicId(int clinicId);
        IDataResult<int> Add(Appointment appointment);
        IResult Update(Appointment appointment);
        IResult Delete(Appointment appointment);
    }
}
