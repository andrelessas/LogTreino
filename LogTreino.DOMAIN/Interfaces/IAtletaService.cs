using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DATA;
using LogTreino.DOMAIN.DTOs;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IAtletaService
    {
        Task<IEnumerable<Atleta>> ObterAtletasAsync();
        Task<Atleta> ObterAtletaAsync(int id);
        Task AlterAtletaAsync(Atleta atleta);
        Task InserirAtletaAsync(Atleta_Insert atletaInsert);
        Task DeleteAtletaAsync(int id);
    }
}