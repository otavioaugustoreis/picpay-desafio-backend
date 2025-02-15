using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Models
{
    public  class TransferenciaModel
    {
        public double NrValor { get; set; }
        public int FkPagador { get; set; }
        public int FkRecebidor { get; set; }
    }
}
