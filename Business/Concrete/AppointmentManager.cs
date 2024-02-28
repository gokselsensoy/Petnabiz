using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private IAppointmentDal _appointmentDal;

        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public IDataResult<int> Add(Appointment appointment)
        {
            _appointmentDal.Add(appointment);
            var result = _appointmentDal.Get(e =>
            e.EntryDate == appointment.EntryDate &&
            e.AppointmentDate == appointment.AppointmentDate &&
            e.VeterinaryClinicId == appointment.VeterinaryClinicId &&
            e.PetId == appointment.PetId &&
            e.AppUserId == appointment.AppUserId);
            if (result != null)
            {
                return new SuccessDataResult<int>(result.Id /*msg*/);
            }
            return new ErrorDataResult<int>(-1 /*msg*/);
        }

        public IResult Delete(Appointment appointment)
        {
            var result = BusinessRules.Run(CheckIfAppointmentIdExist(appointment.Id));
            if (result != null)
            {
                return result;
            }

            var deletedAppointment = _appointmentDal.Get(e => e.Id == appointment.Id);
            _appointmentDal.Delete(deletedAppointment);
            return new SuccessResult(/*msg*/);
        }

        public IDataResult<List<Appointment>> GetAll()
        {
            return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll());
        }

        public bool IsAppointmentAvailable(int clinicId, DateTime selectedDate)
        {
            var existingAppointments = _appointmentDal.IsAppointmentAvailable(clinicId, selectedDate);
            return existingAppointments;
        }

        public IDataResult<List<DateTime>> GetAvailableAppointments(int clinicId, DateTime selectedDate)
        {
            return new SuccessDataResult<List<DateTime>> (_appointmentDal.GetAvailableAppointments(clinicId, selectedDate));
        }

        public IDataResult<List<AppointmentDetailDto>> GetAppointmentDetails(int clinicId)
        {
            return new SuccessDataResult<List<AppointmentDetailDto>>(_appointmentDal.GetAppointmentDetails(clinicId));
        }

        public IDataResult<List<Appointment>> GetByClinicId(int clinicId)
        {
            return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(e => e.VeterinaryClinicId == clinicId));
        }

        public IDataResult<Appointment> GetById(int appointmentId)
        {
            return new SuccessDataResult<Appointment>(_appointmentDal.Get(e => e.Id == appointmentId));
        }

        public IDataResult<List<Appointment>> GetByPetId(int petId)
        {
            return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(e => e.PetId == petId));
        }

        public IDataResult<List<Appointment>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(e => e.AppUserId == userId));
        }

        public IResult Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfAppointmentIdExist(int appointmentId)
        {
            var result = _appointmentDal.GetAll(e => e.Id == appointmentId).Any();
            if (!result)
            {
                return new ErrorResult(/*msg*/);
            }
            return new SuccessResult();
        }
    }
}
