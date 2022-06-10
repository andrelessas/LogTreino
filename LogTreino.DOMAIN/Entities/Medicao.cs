using System;
using System.Collections.Generic;

namespace LogTreino.DATA
{
    public partial class Medicao
    {
        public decimal? Braco { get; set; }
        public decimal? Barriga { get; set; }
        public decimal? Coxa { get; set; }
        public decimal? Peito { get; set; }
        public int? Id { get; set; }
        public DateTime? Data { get; set; }
        public int? IdAtleta { get; set; }

        public virtual Atleta? IdAtletaNavigation { get; set; }
    }
}
