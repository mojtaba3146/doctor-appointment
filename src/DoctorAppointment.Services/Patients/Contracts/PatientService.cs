using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Doctors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientService : Service
    {
        void Add(AddPatientDto dto);
        List<GetAllPatientsDto> GetAllPatients();
        void Delete(int id);
        void Update(int id, UpdatePatientDto dto);
    }
}
