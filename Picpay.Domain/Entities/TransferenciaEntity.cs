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

        public TransferenciaEntity(int pkId, int fkPagador, double nrValor) :
            base(pkId)
        {
            FkCarteira = fkPagador;
            NrValor = nrValor;
        }

        public double  NrValor { get; set; }
        public int FkCarteira  { get; set; }
        public CarteiraEntity Carteira { get; set; } = new();
    }
}
