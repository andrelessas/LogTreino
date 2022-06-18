using System;
using System.Collections.Generic;

namespace LogTreino.DOMAIN
{
    public partial class Treino
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TotalSeries { get; set; }
        public string Descricao { get; set; }
    }
}
