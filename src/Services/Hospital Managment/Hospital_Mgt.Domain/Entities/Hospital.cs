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
        public string  Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public List<string> PhoneNumber { get; set; }
        public List<string> Email { get; set; }
    }
}
