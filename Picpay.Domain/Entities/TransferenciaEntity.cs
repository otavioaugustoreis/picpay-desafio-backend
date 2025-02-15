using Picpay.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Entities
{
    public class TransferenciaEntity : BaseEntity
    {

        public TransferenciaEntity() : base()
        {
        }

        public double  NrValor { get; set; }
        public int FkPagador { get; set; }
        public int FkRecebidor { get; set; }

        public CarteiraEntity Pagador { get; set; }

        public CarteiraEntity Recebedor { get; set; }
    }
}
