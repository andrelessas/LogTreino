using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.DTOs
{
    public class Aparelho_Update
    {
        [Key]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Necessário informar o nome do aparelho.")]
        [MinLength(5,ErrorMessage = "Informe no mínimo 5 caracteres no nome do aparelho.")]
        public string Nome { get; set; }
    }
}