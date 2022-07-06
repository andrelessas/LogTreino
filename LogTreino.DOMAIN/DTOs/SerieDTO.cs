using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.DTOs
{
    public class SerieDTO
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Informe a quantidade de series executadas." )]
        public int Serie1 { get; set; }
        [Required(ErrorMessage = "Informe o peso usado na série." )]
        public int Peso { get; set; }
        [Required(ErrorMessage = "Informe a quantidade de repetições." )]
        public int QtdRepeticoes { get; set; }
    }
}