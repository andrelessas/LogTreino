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
        private readonly FuncoesUteis _uteis = new FuncoesUteis();

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
            var atleta = await _repository.ObterAtletaAsync(id);
            if(atleta == null)
                throw new ExcecaoPersonalizada("Nenhum atleta encontrado.");

            await _repository.DeletarAtletaAsync(atleta,id);
        }

        public async Task InserirAtletaAsync(Atleta_Insert atletaInsert)
        {            
            await _repository.InserirAtletaAsync(_mapper.Map<Atleta>(atletaInsert));
        }

        public async Task<Atleta> ObterAtletaAsync(int id)
        {
            var atleta = await _repository.ObterAtletaAsync(id);
            if(atleta == null)
                throw new ExcecaoPersonalizada("Nenhum atleta encontrado.");

            return atleta;
        }

        public async Task<PaginacaoDTO> ObterAtletasAsync(Paginacao paginacao)
        {
            var qtdAtletas = await _repository.ObterTotalAtletasAsync();
            var parametrosPaginacao = _uteis.TratarPaginacao(paginacao.CurrentPage,paginacao.Limit,qtdAtletas);
            paginacao.CurrentPage = Convert.ToInt32(parametrosPaginacao[1]);
            
            var atletas = await _repository.ObterAtletasAsync(paginacao.CurrentPage,paginacao.Limit);

            if(atletas.Count() == 0)
                throw new ExcecaoPersonalizada("Nenhum atleta encontrado.");
            
            return new PaginacaoDTO
                        {
                            TotalPaginas = parametrosPaginacao[0],
                            Dados = atletas
                        };
        }
    }
}