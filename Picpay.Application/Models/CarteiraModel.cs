using Picpay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Models
{
    public class CarteiraModel
    {
        public int PkId { get; set; }
        public double Saldo { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
