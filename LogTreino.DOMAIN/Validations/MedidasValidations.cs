using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LogTreino.DOMAIN.DTOs;

namespace LogTreino.DOMAIN.Validations
{
    public class MedidasValidations:AbstractValidator<MedidasDTO>
    {
        private string mensagem = "Necessário informado as medidas";
        public MedidasValidations()
        {
            RuleFor(x=>x.Barriga).NotEmpty().NotNull().NotEqual(0).WithMessage($"{mensagem} da Cintura, na linha do Umbigo.");
            RuleFor(x=>x.BicepsD).NotEmpty().NotNull().NotEqual(0).WithMessage($"{mensagem} do Biceps Direto.");
            RuleFor(x=>x.BicepsE).NotEmpty().NotNull().NotEqual(0).WithMessage($"{mensagem} do Biceps Esquerdo.");
            RuleFor(x=>x.Cintura).NotEmpty().NotNull().NotEqual(0).WithMessage($"{mensagem} da Cintura.");
            RuleFor(x=>x.CoxaD).NotEmpty().NotNull().NotEqual(0).WithMessage($"{mensagem} da Coxa Direita.");
            RuleFor(x=>x.CoxaE).NotEmpty().NotNull().NotEqual(0).WithMessage($"{mensagem} da Coxa Esquerda.");
            RuleFor(x=>x.Peito).NotEmpty().NotNull().NotEqual(0).WithMessage($"{mensagem} do Peitoral.");
        }
    }
}