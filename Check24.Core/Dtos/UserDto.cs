using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check24.Core.Dtos
{
    public class UserDto
    {
        public int? Points { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
