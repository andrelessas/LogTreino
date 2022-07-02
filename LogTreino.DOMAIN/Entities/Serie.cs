using System;
using System.Collections.Generic;
using LogTreino.DOMAIN.Entities;

namespace LogTreino.DOMAIN
{
    public partial class Serie:Entity
    {
        public int IdTreinoDia { get; set; }
        public int Serie1 { get; set; }
        public int Peso { get; set; }
        public int QtdRepeticoes { get; set; }

        public virtual TreinoDia IdTreinoDiaNavigation { get; set; }
    }
}
