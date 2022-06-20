using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.DTOs
{
    public class MedidasDTO
    {
        public int IdAtleta { get; set; }
        public DateTime DataMedicao { get; set; }
        public decimal Cintura { get; set; }
        public decimal Barriga { get; set; }
        public decimal Peito { get; set; }
        public decimal CoxaE { get; set; }
        public decimal CoxaD { get; set; }
        public decimal BicepsE { get; set; }
        public decimal BicepsD { get; set; }
   
    }
}