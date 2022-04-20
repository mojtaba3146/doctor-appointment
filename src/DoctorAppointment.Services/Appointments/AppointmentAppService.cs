using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Appointments.Contracts;
using DoctorAppointment.Services.Appointments.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments
{
    public class AppointmentAppService : AppointmentService
    {
        private readonly AppointmentRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public AppointmentAppService(
            AppointmentRepository repository,
            UnitOfWork unitOfWork
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddApointmentDto dto)
        {
            var appointment = new Appointment();
            int VisitsCount, RepeatCount;
            List<int> possibelety = new List<int>();

            possibelety = _repository.
               GetPossibelity(dto.Date, dto.DoctorId, dto.PatientId);

            VisitsCount = possibelety[0];
            RepeatCount = possibelety[1];

            if (VisitsCount <= 5 && RepeatCount == 0)
            {
                appointment.Date = dto.Date;
                appointment.DoctorId = dto.DoctorId;
                appointment.PatientId = dto.PatientId;

                _repository.Add(appointment);
                _unitOfWork.Commit();
            }
            else
            {
                throw new NotEnoughSpaceException();
            }
        }

        public void Delete(int id)
        {
            var appointment = _repository.GetById(id);

            if (appointment == null)
            {
                throw new AppointmentDoesNotExsitException();
            }

            _repository.Delete(appointment);
            _unitOfWork.Commit();
        }

        public List<GetAllAppointmentDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(int id, UpdateAppointmentDto dto)
        {
            var appointment = _repository.GetById(id);
            int VisitsCount, RepeatCount;
            List<int> possibelety = new List<int>();

            if (appointment == null)
            {
                throw new AppointmentDoesNotExsitException();
            }

            possibelety = _repository.
               GetPossibelity(dto.Date, dto.DoctorId, dto.PatientId);

            VisitsCount = possibelety[0];
            RepeatCount = possibelety[1];

            if (VisitsCount <= 5 && RepeatCount == 0)
            {
                appointment.Date = dto.Date;
                appointment.DoctorId = dto.DoctorId;
                appointment.PatientId = dto.PatientId;

                _unitOfWork.Commit();
            }
            else
            {
                throw new NotEnoughSpaceException();
            }
        }
    }
}
