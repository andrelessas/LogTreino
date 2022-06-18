using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LogTreino.DOMAIN.DTOs;

namespace LogTreino.DOMAIN.Validations
{
    public class AtletaValidations:AbstractValidator<Atleta_Insert>
    {
        public AtletaValidations()
        {
            RuleFor(x =>x.Nome).NotEmpty().NotNull();
            RuleFor(x =>x.Email).NotEmpty().NotNull();
            RuleFor(x =>x.Senha).NotEmpty().NotNull();
        }
    }
}