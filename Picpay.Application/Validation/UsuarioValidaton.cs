using FluentValidation;
using Picpay.Application.Models;
using System;

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Validation
{
    public class UsuarioValidaton : AbstractValidator<UsuarioModel>
    {
        public UsuarioValidaton()
        {
            RuleFor(x => x.DsNome)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(55);

            RuleFor(x => x.DsCpf)
                     .NotEmpty()
                     .Length(11)
                     .Must(CpfValidation.ValidarFormatoCpf)
                     .WithMessage("O cpf informado não é válido.");

            RuleFor(x => x.DsEmail)
                     .NotEmpty()
                      .MinimumLength(10)
                      .MaximumLength(55);

            RuleFor(x => x.DsSenha)
                     .NotEmpty()
                      .MinimumLength(10)
                      .MaximumLength(20);

        }
    }
}
