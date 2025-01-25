using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Entities
{
    public  class CarteiraEntity
    {
        public  int PkId { get; set; }

        public  double Saldo { get; set; }

        public  int  FkUsuario { get; set; }
        public Usuario? Usuario { get; set; }


        public CarteiraEntity() 
        { }

        public CarteiraEntity(int pkId, double saldo, Usuario? usuario)
        {
            PkId = pkId;
            Saldo = saldo;
            Usuario = usuario;
        }
    }
}
