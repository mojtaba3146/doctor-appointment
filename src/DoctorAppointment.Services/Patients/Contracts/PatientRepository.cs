using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientRepository : Repository
    {
        void Add(Patient patient);
        Patient GetById(int id);
        void Delete(Patient patient);
        List<GetAllPatientsDto> GetAllPatients();
        bool IsExistNationalCode(string nationalCode);
        bool IsExistNationalCodeWithId(string nationalName,int id);
    }
}
