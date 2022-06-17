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
            RuleFor(x =>x.Nome).NotEmpty();
            RuleFor(x =>x.Email).NotEmpty();
            RuleFor(x =>x.Senha).NotEmpty();
        }
    }
}