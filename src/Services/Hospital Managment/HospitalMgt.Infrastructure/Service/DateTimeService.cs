using EHR.SAS.Common.Application.Abstraction;
using System;

namespace HospitalMgt.Infrastructure.Service
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
