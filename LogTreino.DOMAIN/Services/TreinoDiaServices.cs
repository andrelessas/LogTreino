using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LogTreino.CORE.ExcecoesPersonalisadas;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Interfaces;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Services
{
    public class TreinoDiaServices : ITreinoDiaServices
    {
        private readonly ITreinoDiaRepository _repository;
        private readonly IMapper _mapper;
        private Paginacao _paginacao = new Paginacao();

        public TreinoDiaServices(ITreinoDiaRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AlterarTreinoDiaAsync(TreinoDiaDTO treinoDiaDTO)
        {
            await _repository.AlterarAsync(_mapper.Map<TreinoDia>(treinoDiaDTO));
        }

        public async Task ExcluirTreinoDiaAsync(int id)
        {
            await _repository.ExcluirAsync(id);
        }

        public async Task InserirTreinoDiaAsync(TreinoDiaDTO treinoDiaDTO)
        {
            await _repository.InserirAsync(_mapper.Map<TreinoDia>(treinoDiaDTO));
        }

        public async Task<TreinoDiaDTO> ObterTreinoDiaPorID(int id)
        {
            var treinoDiaDTO = _mapper.Map<TreinoDiaDTO>(await _repository.ObterPorIDAsync(id));
            if(treinoDiaDTO == null)
                throw new ExcecoesPersonalizadas("Nenhum treino encontrado.");
            return treinoDiaDTO;
        }

        public async Task<Retorno_Paginado> ObterTreinosPorAtleta(int idAtleta, PaginacaoDTO paginacaoDTO)
        {
            var totalTreinos = await _repository.ObterTotalTreinoDias(idAtleta);
            _paginacao = _paginacao.TratarPaginacao(paginacaoDTO.CurrentPage,paginacaoDTO.Limit,totalTreinos);
            var treinoPorAtleta = await _repository.ObterTreinosPorAtleta(idAtleta,_paginacao);
            if(treinoPorAtleta == null)
                throw new ExcecoesPersonalizadas("Nenhum treino encontrado.");
            return new Retorno_Paginado
                        {
                            TotalPaginas = _paginacao.TotalPaginas,
                            Dados = _mapper.Map<IEnumerable<TreinoDiaDTO>>(treinoPorAtleta)
                        };
        }

        public async Task<Retorno_Paginado> ObterTreinosPorPeriodo(DateTime dataInicial, DateTime dataFinal, PaginacaoDTO paginacaoDTO)
        {
            var totalTreinos = await _repository.ObterTotalTreinoDias(dataInicial,dataFinal);
            _paginacao = _paginacao.TratarPaginacao(paginacaoDTO.CurrentPage,paginacaoDTO.Limit,totalTreinos);
            var treinoPorData = await _repository.ObterTreinosPorPeriodo(dataInicial,dataFinal,_paginacao);
            if(treinoPorData == null)
                throw new ExcecoesPersonalizadas("Nenhum treino encontrado.");
            return new Retorno_Paginado
                        {
                            TotalPaginas = _paginacao.TotalPaginas,
                            Dados = _mapper.Map<IEnumerable<TreinoDiaDTO>>(treinoPorData)
                        };   
        }
    }
}