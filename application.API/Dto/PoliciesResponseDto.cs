using application.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.Dto
{
    public class PoliciesResponseDto
    {
        public IEnumerable<Post> Policies { get; set; }
    }
}
