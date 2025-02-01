using FluentValidation;
using Picpay.Application.Models;
using Picpay.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string  DsNome { get; set; }
        public string DsCpf   { get; set; }
        public string DsEmail { get; set; }
        public string DsSenha { get; set; }
        public double Saldo   { get; set; }
        public TipoUsuario TipoConta  { get; set; }
    }
}
