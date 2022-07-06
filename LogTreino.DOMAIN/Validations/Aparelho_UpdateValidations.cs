using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LogTreino.DOMAIN.DTOs;

namespace LogTreino.DOMAIN.Validations
{
    public class Aparelho_UpdateValidations:AbstractValidator<Aparelho_Update>
    {
        public Aparelho_UpdateValidations()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull();
        }
    }
}