using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Doctors
{
    public class EFDoctorRepository : DoctorRepository
    {
        private readonly DbSet<Doctor> _doctors;

        public EFDoctorRepository(ApplicationDbContext dbcontext)
        {
            _doctors = dbcontext.Set<Doctor>();
        }

        public void Add(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _doctors.Remove(doctor);
        }

        public List<GetAllDoctorsDto> GetAllDoctors()
        {
            return _doctors.Select(x => new GetAllDoctorsDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Field = x.Field,
            }).ToList();
        }

        public Doctor GetById(int id)
        {
            return _doctors
                .FirstOrDefault(x => x.Id == id);
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _doctors
                .Any(_ => _.NationalCode == nationalCode);
        }

        public bool IsExistNationalCodeWithId(string nationalCode, int id)
        {
            return _doctors
                .Any(_=> _.NationalCode==nationalCode && _.Id != id);
        }
    }
}
