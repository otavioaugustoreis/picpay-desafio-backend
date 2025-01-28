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
    public class TransferenciaValidator : AbstractValidator<TransferenciaModel>
    {
        public TransferenciaValidator()
        {
            RuleFor(x => x.NrValor)
                     .NotEmpty()
                     .WithName("idPagador");
        }
=======
    public class TransferenciaValidator
    {
>>>>>>> e6da564af281f9048cfdacb512d67e78beeba950
    }
}
