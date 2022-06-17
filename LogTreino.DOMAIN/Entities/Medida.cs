using System;
using System.Collections.Generic;

namespace LogTreino.DOMAIN
{
    public partial class Medida
    {
        public int Id { get; set; }
        public int? IdAtleta { get; set; }
        public DateTime? DataMedicao { get; set; }
        public decimal? Cintura { get; set; }
        public decimal? Barriga { get; set; }
        public decimal? Peito { get; set; }
        public decimal? CoxaE { get; set; }
        public decimal? CoxaD { get; set; }
        public decimal? BicepsE { get; set; }
        public decimal? BicepsD { get; set; }

        public virtual Atleta? IdAtletaNavigation { get; set; }
    }
}
