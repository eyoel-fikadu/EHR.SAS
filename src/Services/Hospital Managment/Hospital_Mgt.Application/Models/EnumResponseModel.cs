using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Models
{
    public class EnumResponseModel
    {
        public string enumKey { get; set; }
        public List<KeyValuePair<string, string>> enums { get; set; }
    }
}
