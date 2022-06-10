using System;
using System.Collections.Generic;

namespace LogTreino.DATA
{
    public partial class Atleta
    {
        public Atleta()
        {
            TreinoRealizados = new HashSet<TreinoRealizado>();
            Treinos = new HashSet<Treino>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        public virtual ICollection<TreinoRealizado> TreinoRealizados { get; set; }
        public virtual ICollection<Treino> Treinos { get; set; }
    }
}
