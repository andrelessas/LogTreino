using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using LogTreino.DATA;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Interfaces
{
    public interface IAtletaService
    {
        Task<PaginacaoDTO> ObterAtletasAsync(Paginacao paginacao);
        Task<Atleta> ObterAtletaAsync(int id);
        Task AlterarAtletaAsync(Atleta atleta);
        Task InserirAtletaAsync(Atleta_Insert atletaInsert);
        Task DeleteAtletaAsync(int id);
    }
}