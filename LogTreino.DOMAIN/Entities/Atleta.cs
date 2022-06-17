using System;
using System.Collections.Generic;

namespace LogTreino.DOMAIN
{
    public partial class Atleta
    {
        public Atleta()
        {
            Medida = new HashSet<Medida>();
            TreinoDia = new HashSet<TreinoDia>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        public virtual ICollection<Medida> Medida { get; set; }
        public virtual ICollection<TreinoDia> TreinoDia { get; set; }
    }
}
