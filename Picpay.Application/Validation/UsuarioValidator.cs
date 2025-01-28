<<<<<<< HEAD
﻿using FluentValidation;
using Picpay.Application.Models;
using System;
=======
﻿using System;
>>>>>>> e6da564af281f9048cfdacb512d67e78beeba950
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Validation
{
<<<<<<< HEAD
    public class UsuarioValidator : AbstractValidator<UsuarioModel>
    {
        public UsuarioValidator()
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

=======
    public class UsuarioValidator
    {
>>>>>>> e6da564af281f9048cfdacb512d67e78beeba950
    }
}
