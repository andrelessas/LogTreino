using System;
using System.Collections.Generic;

namespace LogTreino.DATA
{
    public partial class TreinoRealizado
    {
        public TreinoRealizado()
        {
            Series = new HashSet<Serie>();
        }

        public int Id { get; set; }
        public int? IdAtleta { get; set; }
        public DateTime? Data { get; set; }

        public virtual Atleta? IdAtletaNavigation { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
    }
}
