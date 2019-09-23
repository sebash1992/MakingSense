using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.Common.Models
{
    public class ResponseHeader
    {
        public int TotalItems { get; set; }
        public ResponseHeader(int totalItems)
        {
            TotalItems = totalItems;
        }
    }
}
