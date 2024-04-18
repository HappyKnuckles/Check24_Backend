using Check24.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check24.Core.dtos
{
    public class CommunityMembersDto
    {
        public Guid CommunityId { get; set; }
        public string CommunityName { get; set; } 
        public List<User> Members { get; set; }
    }
}
