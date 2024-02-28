using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfAppointmentDal : EfEntityRepositoryBase<Appointment, PetnabizDatabaseContext>, IAppointmentDal
    {
        public List<DateTime> GetAvailableAppointments(int clinicId, DateTime selectedDate)
        {
            using (PetnabizDatabaseContext context = new PetnabizDatabaseContext())
            {
                var existingAppointments = context.Appointments
                    .Where(a => a.VeterinaryClinicId == clinicId && a.AppointmentDate == selectedDate)
                    .ToList();

                TimeSpan workStartTime = new TimeSpan(9, 0, 0);
                TimeSpan workEndTime = new TimeSpan(18, 0, 0);

                var allTimes = new List<DateTime>();
                DateTime currentTime = selectedDate.Date.Add(workStartTime);
                while (currentTime.TimeOfDay <= workEndTime)
                {
                    allTimes.Add(currentTime);
                    currentTime = currentTime.AddMinutes(30);
                }

                foreach (var appointment in existingAppointments)
                {
                    DateTime bookedTime = selectedDate.Date.Add(appointment.AppointmentDate.TimeOfDay);
                    allTimes.RemoveAll(t => t == bookedTime);
                }

                return allTimes;
            }
        }

        public bool IsAppointmentAvailable(int clinicId, DateTime selectedDate)
        {
            using (PetnabizDatabaseContext context = new PetnabizDatabaseContext())
            {
                var existingAppointments = context.Appointments
                .Where(a => a.VeterinaryClinicId == clinicId && a.AppointmentDate == selectedDate)
                .ToList();

                // Eğer hiç randevu yoksa, bu zaman dilimi boştur.
                return existingAppointments.Count == 0;
            }
        }

        public List<AppointmentDetailDto> GetAppointmentDetails(int clinicId)
        {
            using (PetnabizDatabaseContext context = new PetnabizDatabaseContext())
            {
                var result = from e in context.Appointments
                             join p in context.Pets
                             on e.PetId equals p.Id
                             join u in context.Users
                             on e.AppUserId equals u.Id
                             where e.VeterinaryClinicId == clinicId
                             select new AppointmentDetailDto
                             {
                                 PetName = p.Name,
                                 PetSpecies = p.Species,
                                 PetBreed = p.Breed,
                                 FirstName = u.Name,
                                 LastName = u.Surname,
                                 EntryDate = e.EntryDate,
                                 AppointmentDate = e.AppointmentDate


                             };
                return result.ToList();
            }
        }
    }
}
