using Picpay.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Entities
{
    public  class LojistaEntity : Usuario
    {

        public LojistaEntity()
        {
        }

        public LojistaEntity(string pkId, string dsNome, string dsCPF, string dsEmail, string dsSenha) : base(pkId, dsNome, dsCPF, dsEmail, dsSenha)
        {
            TgTipo = TipoUsuario.LOJISTA;
        }
    }
}
