using HospitalMgt.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Domain.Entities
{
    public class Subscription : EntityBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Contract { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public Double Amount { get; set; }
    }
}
