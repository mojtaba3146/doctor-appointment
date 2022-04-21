﻿using DoctorAppointment.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public interface AppointmentService : Service
    {
        void Add(AddApointmentDto dto);
        List<GetAllAppointmentDto> GetAll();
        void Delete(int id);
        void Update(int id, UpdateAppointmentDto dto);
    }
}
