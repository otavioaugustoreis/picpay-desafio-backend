using Picpay.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Entities
{
    public  class UsuarioEntity : BaseEntity
    {
        public UsuarioEntity()
        {
        }

        public UsuarioEntity(int pkId, string dsNome, string dsCPF, string dsEmail, string dsSenha)
            :base(pkId)
        {
            DsNome = dsNome;
            DsCPF = dsCPF;
            DsEmail = dsEmail;
            DsSenha = dsSenha;
        }

        public List<CarteiraEntity> CarteiraEntities { get; set; } = new();
        public  string DsNome { get;   set; }
        public  string DsCPF { get; protected set; }
        public  string DsEmail { get; set; }
        public  string DsSenha { get; protected set; }
        public TipoUsuario TgTipo { get; set; } 
    
        public void AdicionarCarteira(CarteiraEntity carteiraEntity)
        {
            CarteiraEntities.Add(carteiraEntity);   
        }
    }
}
