using System;
using System.Collections.Generic;
using LogTreino.DOMAIN.Entities;

namespace LogTreino.DOMAIN
{
    public partial class Treino:Entity
    {
        public string Nome { get; set; }
        public int TotalSeries { get; set; }
        public string Descricao { get; set; }
    }
}
