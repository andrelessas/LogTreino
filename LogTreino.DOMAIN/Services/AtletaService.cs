using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LogTreino.CORE.ExcecoesPersonalisadas;
using LogTreino.CORE.Utils;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Interfaces;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Services
{
    public class AtletaService:IAtletaService
    {
        private readonly IAtletaRepository _repository;
        private readonly IMapper _mapper;
        private Paginacao _paginacao = new Paginacao();

        public AtletaService(IAtletaRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AlterarAtletaAsync(Atleta atleta)
        {
            await _repository.AlterarAtletaAsync(atleta);
        }

        public async Task DeleteAtletaAsync(int id)
        {
            var atleta = await _repository.ObterAtletaPorIDAsync(id);
            if(atleta == null)
                throw new ExcecoesPersonalizadas("Nenhum atleta encontrado.");

            await _repository.DeletarAtletaAsync(atleta);
        }

        public async Task InserirAtletaAsync(Atleta_Insert atletaInsert)
        {            
            await _repository.InserirAtletaAsync(_mapper.Map<Atleta>(atletaInsert));
        }

        public async Task<Atleta> ObterAtletaPorIDAsync(int id)
        {
            var atleta = await _repository.ObterAtletaPorIDAsync(id);
            if(atleta == null)
                throw new ExcecoesPersonalizadas("Nenhum atleta encontrado.");

            return atleta;
        }

        public async Task<IEnumerable<Atleta>> ObterAtletaPorNome(string nome)
        {
            var atletas = await _repository.ObterAtletaPorNome(nome);
            if(atletas.Count() == 0)
                throw new ExcecoesPersonalizadas("Nenhum atleta encontrado.");
            
            return atletas;
        }

        public async Task<Retorno_Paginado> ObterAtletasAsync(PaginacaoDTO paginacaoDTO)
        {
            var qtdAtletas = await _repository.ObterTotalAtletasAsync();
            _paginacao = _paginacao.TratarPaginacao(paginacaoDTO.CurrentPage,paginacaoDTO.Limit,qtdAtletas);
            var atletas = await _repository.ObterAtletasAsync(_paginacao.CurrentPage,_paginacao.Limit);

            if(atletas.Count() == 0)
                throw new ExcecoesPersonalizadas("Nenhum atleta encontrado.");
            
            return new Retorno_Paginado
                        {
                            TotalPaginas = _paginacao.TotalPaginas,
                            Dados = atletas
                        };
        }
    }
}