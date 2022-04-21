using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorService : Service
    {
        void Add(AddDoctorDto dto);
        List<GetAllDoctorsDto> GetAllDoctors();
        void Delete(int id);
        void Update(int id,UpdateDoctorDto dto);
        
    }
}
