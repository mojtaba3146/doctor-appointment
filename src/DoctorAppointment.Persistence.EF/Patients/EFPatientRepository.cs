using DoctorAppointment.Entities;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Patients
{
    public class EFPatientRepository : PatientRepository
    {
        private readonly DbSet<Patient> _patients;

        public EFPatientRepository(ApplicationDbContext dbcontext)
        {
            _patients = dbcontext.Set<Patient>();
        }
        public void Add(Patient patient)
        {
            _patients.Add(patient);
        }

        public void Delete(Patient patient)
        {
            _patients.Remove(patient);
        }

        public List<GetAllPatientsDto> GetAllPatients()
        {
            return _patients.Select(p => new GetAllPatientsDto
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                NationalCode = p.NationalCode,
            }).ToList();
        }

        public Patient GetById(int id)
        {
            return _patients.
                FirstOrDefault(p => p.Id == id);
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _patients
                .Any(p => p.NationalCode == nationalCode);
        }

        public bool IsExistNationalCodeWithId(string nationalCode, int id)
        {
            return _patients
                .Any(p => p.NationalCode == nationalCode && p.Id != id);
        }
    }
}
