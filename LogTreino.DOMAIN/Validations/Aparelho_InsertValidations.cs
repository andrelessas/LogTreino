using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LogTreino.DOMAIN.DTOs;

namespace LogTreino.DOMAIN.Validations
{
    public class Aparelho_InsertValidations:AbstractValidator<Aparelho_Insert>
    {
        public Aparelho_InsertValidations()
        {
            RuleFor(x=>x.Nome).NotNull().NotEmpty();
        }
    }
}