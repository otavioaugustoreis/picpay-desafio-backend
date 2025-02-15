using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Entities
{
    public  class CarteiraEntity : BaseEntity
    {

        public CarteiraEntity()
        { }

        public CarteiraEntity( double saldo, UsuarioEntity? usuario)
        {
            Saldo = saldo;
            Usuario = usuario;
        }
        public  double Saldo { get; set; }
        public  int  FkUsuario { get; set; }
        public UsuarioEntity? Usuario { get; set; }

        public ICollection<TransferenciaEntity> TransferenciasComoPagador { get; set; }

        public ICollection<TransferenciaEntity> TransferenciasComoRecebedor { get; set; }

        public void AdicionarTransferenciaComoPagador(TransferenciaEntity transferencia)
        {
            TransferenciasComoPagador.Add(transferencia);
        }

        public void AdicionarTransferenciaComoRecebedor(TransferenciaEntity transferencia)
        {
            TransferenciasComoRecebedor.Add(transferencia);
        }

    }
}
