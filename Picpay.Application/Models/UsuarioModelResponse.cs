using Picpay.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Models
{
    public class UsuarioModelResponse
    {
        public int PkId { get; set; }
        public string DsNome { get; set; }
        public string DsCPF { get; set; }
        public string DsEmail { get; set; }

        public string Tipo
        {
            get
            {
                if (TgTipo.Equals(TipoUsuario.LOJISTA)){
                    return "Lojista";
                }
                return TipoUsuario.COMUM.ToString() ;
            }
        }
        public TipoUsuario TgTipo { get; set; }
    }
}
