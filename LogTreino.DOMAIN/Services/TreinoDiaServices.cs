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
            var treinoDia = _mapper.Map<TreinoDia>(treinoDiaDTO);
            await _repository.AlterarTreinoDiaAsync(treinoDia);
        }

        public async Task ExcluirTreinoDiaAsync(int id)
        {
            var treinoDia = await _repository.ObterTreinoDiaPorID(id);
            if(treinoDia == null)
                throw new ExcecoesPersonalizadas("treino não encontrado.");
            await _repository.ExcluirTreinoDiaAsync(treinoDia);
        }

        public async Task InserirTreinoDiaAsync(TreinoDiaDTO treinoDiaDTO)
        {
            var treinoDias = _mapper.Map<TreinoDia>(treinoDiaDTO);
            await _repository.InserirTreinoDiaAsync(treinoDias);
        }

        public async Task<TreinoDiaDTO> ObterTreinoDiaPorID(int id)
        {
            var treinoDiaDTO = _mapper.Map<TreinoDiaDTO>(await _repository.ObterTreinoDiaPorID(id));
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