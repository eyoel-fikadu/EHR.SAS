using HospitalMgt.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Domain.Entities
{
    public class Hospital : EntityBase
    {
        public string  name { get; set; }
        public string description { get; set; }
    }
}
