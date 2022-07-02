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
            await _repository.AlterarAsync(atleta);
        }

        public async Task DeleteAtletaAsync(int id)
        {
            await _repository.ExcluirAsync(id);
        }

        public async Task InserirAtletaAsync(Atleta_Insert atletaInsert)
        {       
            var atleta = _mapper.Map<Atleta>(atletaInsert);
            await _repository.InserirAsync(atleta);
        }

        public async Task<Atleta_Insert> ObterAtletaPorIDAsync(int id)
        {
            var atleta = await _repository.ObterPorIDAsync(id);
            if(atleta == null)
                throw new ExcecoesPersonalizadas("Nenhum atleta encontrado.");

            return _mapper.Map<Atleta_Insert>(atleta);
        }

        public async Task<IEnumerable<Atleta_Insert>> ObterAtletaPorNome(string nome)
        {
            var atletas = await _repository.ObterAtletaPorNome(nome);
            if(atletas.Count() == 0)
                throw new ExcecoesPersonalizadas("Nenhum atleta encontrado.");
            
            return _mapper.Map<IEnumerable<Atleta_Insert>>(atletas);
        }

        public async Task<Retorno_Paginado> ObterAtletasAsync(PaginacaoDTO paginacaoDTO)
        {
            var qtdAtletas = await _repository.ObterTotalAtletasAsync();
            _paginacao = _paginacao.TratarPaginacao(paginacaoDTO.CurrentPage,paginacaoDTO.Limit,qtdAtletas);
            var atletas = await _repository.ObterTodosAsync(_paginacao);

            if(atletas.Count() == 0)
                throw new ExcecoesPersonalizadas("Nenhum atleta encontrado.");
            
            return new Retorno_Paginado
                        {
                            TotalPaginas = _paginacao.TotalPaginas,
                            Dados = _mapper.Map<IEnumerable<Atleta_Insert>>(atletas)
                        };
        }
    }
}