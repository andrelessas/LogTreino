using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LogTreino.CORE.ExcecoesPersonalisadas;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.DTOs.Consultas;
using LogTreino.DOMAIN.Interfaces;
using LogTreino.DOMAIN.Pagination;

namespace LogTreino.DOMAIN.Services
{
    public class MedidasService : IMedidasService
    {
        private readonly IMedidasRepository _medidaRepository;
        private readonly IAtletaRepository _atletaRepository;
        private readonly IMapper _mapper;
        private Paginacao _paginacao = new Paginacao();

        public MedidasService(IMedidasRepository medidaRepository, IAtletaRepository atletaRepository, IMapper mapper)
        {
            _medidaRepository = medidaRepository;
            _atletaRepository = atletaRepository;
            _mapper = mapper;
        }
        public async Task AlterarMedidaAsync(int id, MedidasDTO medidasDTO)
        {
            var medida = _mapper.Map<Medida>(medidasDTO);
            medida.Id = id;
            await _medidaRepository.AlterarMedidaAsync(medida);
        }
        public async Task ExcluirMedidaAsync(int id)
        {
            var medida = await _medidaRepository.ObterMedidaPorIDAsync(id);
            if(medida == null)
                throw new ExcecoesPersonalizadas("Nenhuma medida encontrada.");
            await _medidaRepository.ExcluirMedidaAsync(medida);
        }
        public async Task InserirMedidaAsync(MedidasDTO medidasDTO)
        {
            var atleta = await _atletaRepository.ObterAtletaPorIDAsync(medidasDTO.IdAtleta);
            if(atleta == null)
                throw new ExcecoesPersonalizadas("O atleta não existe");
                
            await _medidaRepository.InserirMedidaAsync(_mapper.Map<Medida>(medidasDTO));
        }
        public async Task<Medida> ObterMedidaPorIDAsync(int id)
        {
            var medida = await _medidaRepository.ObterMedidaPorIDAsync(id);
            if(medida == null)
                throw new ExcecoesPersonalizadas("Nenhuma medida encontrada.");
            return medida;
        }
        public async Task<Retorno_Paginado> ObterMedidasPorAtletaAsync(int idAtleta, PaginacaoDTO paginacaoDTO)
        {
            var totalMedidas = await _medidaRepository.ObterTotalMedidasAsync(idAtleta);
            _paginacao = _paginacao.TratarPaginacao(paginacaoDTO.CurrentPage,paginacaoDTO.Limit,totalMedidas);
            var medidas = await _medidaRepository.ObterMedidasPorAtletaAsync(idAtleta,_paginacao);
            if (medidas.Count() == 0)
                throw new ExcecoesPersonalizadas("Não foi encontrada nenhuma medida para o atleta informado.");
            
            return new Retorno_Paginado
                        {
                            TotalPaginas = _paginacao.TotalPaginas,
                            Dados = medidas
                        };
        }
        public async Task<Retorno_Paginado> ObterMedidasPorPeriodoAsync(MedidasAtletaPorPeriodo medidasAtletaPorPeriodo)
        {
            var totalMedidas = await _medidaRepository.ObterTotalMedidasAsync(medidasAtletaPorPeriodo);
            _paginacao = _paginacao.TratarPaginacao(medidasAtletaPorPeriodo.CurrentPage,medidasAtletaPorPeriodo.Limit,totalMedidas);
            var medidas = await _medidaRepository.ObterMedidasPorPeriodoAsync(medidasAtletaPorPeriodo,_paginacao);
            if (medidas.Count() == 0)
                throw new ExcecoesPersonalizadas("Não foi encontrada nenhuma medida no periodo informado.");
            
            return new Retorno_Paginado
                        {
                            TotalPaginas = _paginacao.TotalPaginas,
                            Dados = medidas
                        };    
        }
    }
}