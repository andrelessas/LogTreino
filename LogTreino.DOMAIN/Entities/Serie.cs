using System;
using System.Collections.Generic;

namespace LogTreino.DATA
{
    public partial class Serie
    {
        public int Id { get; set; }
        public int? Repeticoes { get; set; }
        public int? Peso { get; set; }
        public int? IdTreino { get; set; }
        public int? IdTreinoRealizado { get; set; }

        public virtual Treino? IdTreinoNavigation { get; set; }
        public virtual TreinoRealizado? IdTreinoRealizadoNavigation { get; set; }
    }
}
