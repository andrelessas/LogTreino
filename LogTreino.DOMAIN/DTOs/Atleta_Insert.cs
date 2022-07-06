using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.DTOs
{
    public class Atleta_Insert
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Informe o nome do atleta.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o email do atleta.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha de acesso ao App.")]
        [MinLength(5,ErrorMessage = "Informe uma senha de no mínimo 5 caracteres.")]
        public string Senha { get; set; }    
        public IEnumerable<MedidasDTO> MedidasDTO { get; set; }    
        public IEnumerable<TreinoDiaDTO> TreinoDiaDTO { get; set; }
    }
}