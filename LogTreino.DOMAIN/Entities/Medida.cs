using System;
using System.Collections.Generic;
using LogTreino.DOMAIN.Entities;

namespace LogTreino.DOMAIN
{
    public partial class Medida:Entity
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

        public virtual Atleta IdAtletaNavigation { get; set; }
    }
}
