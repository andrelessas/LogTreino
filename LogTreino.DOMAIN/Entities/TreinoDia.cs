using System;
using System.Collections.Generic;

namespace LogTreino.DOMAIN
{
    public partial class TreinoDia
    {
        public TreinoDia()
        {
            Series = new HashSet<Serie>();
        }

        public int Id { get; set; }
        public int IdAtleta { get; set; }
        public DateTime Data { get; set; }
        public int IdAparelho { get; set; }

        public virtual Atleta IdAtletaNavigation { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
    }
}
