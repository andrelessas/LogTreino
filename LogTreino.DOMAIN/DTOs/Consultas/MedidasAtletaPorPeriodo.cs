using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.DTOs.Consultas
{
    public class MedidasAtletaPorPeriodo:PaginacaoDTO
    {
        public int IdAtleta { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}