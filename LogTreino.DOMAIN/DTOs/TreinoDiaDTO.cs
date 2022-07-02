using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogTreino.DOMAIN.DTOs
{
    public class TreinoDiaDTO
    {
        public int ID { get; set; }
        public int IDAtleta { get; set; }
        public DateTime Data { get; set; }
        public virtual ICollection<SerieDTO> SeriesDTO { get; set; }        
    }
}