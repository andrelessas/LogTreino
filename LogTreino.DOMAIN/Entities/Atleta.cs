using System;
using System.Collections.Generic;
using LogTreino.DOMAIN.Entities;

namespace LogTreino.DOMAIN
{
    public partial class Atleta:Entity
    {
        public Atleta()
        {
            Medida = new HashSet<Medida>();
            TreinoDia = new HashSet<TreinoDia>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Medida> Medida { get; set; }
        public virtual ICollection<TreinoDia> TreinoDia { get; set; }
    }
}
