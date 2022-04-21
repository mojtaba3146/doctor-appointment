using DoctorAppointment.Entities;
using DoctorAppointment.Services.Appointments.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Appointments
{
    public class EFAppointmentRepository : AppointmentRepository
    {
        private readonly DbSet<Appointment> _Appointment;

        public EFAppointmentRepository(ApplicationDbContext dbcontext)
        {
            _Appointment = dbcontext.Set<Appointment>();
        }

        public void Add(Appointment appointment)
        {
            _Appointment.Add(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _Appointment.Remove(appointment);
        }

        public List<GetAllAppointmentDto> GetAll()
        {
            return _Appointment.Select(x => new GetAllAppointmentDto
            {
                Date = x.Date,
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
            }).ToList();
        }

        public Appointment GetById(int id)
        {
            return _Appointment.
                FirstOrDefault(x => x.Id == id);    
        }

        public PossibelityDto GetPossibelity(DateTime dateTime, int doctorId, int patientId)
        {
            var VisitsCount = _Appointment.Where(x => x.DoctorId == doctorId &&
             x.Date == dateTime).Count();

            var RepeatCount= _Appointment.Where(x => x.DoctorId == doctorId &&
             x.Date == dateTime && x.PatientId == patientId).Count();

            PossibelityDto possibelityDto = new PossibelityDto
            {
                VisitCount = VisitsCount,
                ReapetCount = RepeatCount,
            };

            return possibelityDto;    
        }
    }
}
