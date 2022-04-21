using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorRepository : Repository
    {
        void Add(Doctor doctor);
        Doctor GetById(int id);
        void Delete(Doctor doctor);
        List<GetAllDoctorsDto> GetAllDoctors();
        bool IsExistNationalCode(string nationalCode);
        bool IsExistNationalCodeWithId(string nationalCode,int id);
        
    }
}
