using FluentValidation;
using Picpay.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picpay.Application.Validation
{
    public class TransferenciaValidator : AbstractValidator<TransferenciaModel>
    {
        public TransferenciaValidator()
        {
            RuleFor(x => x.NrValor)
                 .NotEmpty()
                 .WithName("value");

            RuleFor(x => x.FkRecebidor)
                .NotEmpty()
                .WithName("payee");

            RuleFor(x => x.FkPagador)
                .NotEmpty()
                .WithName("payer");
        }
    }
}
