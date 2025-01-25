using Picpay.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Domain.Entities
{
    public abstract class Usuario
    {
        protected Usuario()
        {
        }

        protected Usuario(string pkId, string dsNome, string dsCPF, string dsEmail, string dsSenha)
        {
            PkId = pkId;
            DsNome = dsNome;
            DsCPF = dsCPF;
            DsEmail = dsEmail;
            DsSenha = dsSenha;
        }

        public  string  PkId { get; protected  set; }
        public  string DsNome { get; protected  set; }
        public  string DsCPF { get; protected set; }
        public  string DsEmail { get; set; }
        public  string DsSenha { get; protected set; }
        public TipoUsuario? TgTipo { get; set; } = null;
    }
}
