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

        public TransferenciaEntity(int pkId, int fkPagador, double nrValor, int fkRecebidor) :
            base(pkId)
        {
            FkRecebidor = fkRecebidor;
            FkPagador = fkPagador;
            NrValor = nrValor;
        }

        public double  NrValor { get; set; }
        public int FkPagador { get; set; }
        public int FkRecebidor { get; set; }

        public CarteiraEntity Carteira { get; set; } = new();
    }
}
