using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Entities
{
    public  class AutorizadorResponse
    {
        public string status { get; set; }
        public AuthorizationData data { get; set; }
    }
}
