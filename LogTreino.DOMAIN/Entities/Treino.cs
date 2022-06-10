using System;
using System.Collections.Generic;

namespace LogTreino.DATA
{
    /// <summary>
    /// Treino agendado para o dia
    /// </summary>
    public partial class Treino
    {
        public Treino()
        {
            Series = new HashSet<Serie>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? IdSerie { get; set; }
        public int? IdAparelho { get; set; }
        public int? IdAtleta { get; set; }

        public virtual Atleta? IdAtletaNavigation { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
    }
}
