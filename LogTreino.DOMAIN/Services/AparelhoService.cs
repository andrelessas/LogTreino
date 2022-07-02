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
    public class AparelhoService : IAparelhoService
    {
        private readonly IAparelhoRepository _repository;
        private readonly IMapper _mapper;
        private Paginacao _paginacao = new Paginacao();

        public AparelhoService(IAparelhoRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AlterarAparelhoAsync(Aparelho_Update aparelho_Update)
        {
            await _repository.AlterarAsync(_mapper.Map<Aparelho>(aparelho_Update));
        }

        public async Task ExcluirAparelhoAsync(int id)
        {
            await _repository.ExcluirAsync(id);
        }

        public async Task InserirAparelhoAsync(Aparelho_Insert aparelho_Insert)
        {
            await _repository.InserirAsync(_mapper.Map<Aparelho>(aparelho_Insert));
        }

        public async Task<Aparelho_Update> ObterAparelhoPorIDAsync(int id)
        {
            var aparelho = _mapper.Map<Aparelho_Update>(await _repository.ObterPorIDAsync(id));
            if(aparelho == null)
                throw new ExcecoesPersonalizadas("Aparelho não encontrado.");
            
            return aparelho;
        }

        public async Task<Retorno_Paginado> ObterAparelhosAsync(PaginacaoDTO paginacaoDTO)
        {
            var totalAparelhos = await _repository.ObterTotalAparelhosAsync();
            _paginacao = _paginacao.TratarPaginacao(paginacaoDTO.CurrentPage,paginacaoDTO.Limit,totalAparelhos);
            var aparelhos = _mapper.Map<IEnumerable<Aparelho_Update>>(await _repository.ObterTodosAsync(_paginacao));
            if(aparelhos.Count() == 0)
                throw new ExcecoesPersonalizadas("Nenhum aparelho encontrado.");
            
            return new Retorno_Paginado
                        {
                            TotalPaginas = totalAparelhos,
                            Dados = aparelhos
                        };
        }
    }
}