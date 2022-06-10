using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.DTOs
{
    public class Atleta_Insert
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }        
    }
}