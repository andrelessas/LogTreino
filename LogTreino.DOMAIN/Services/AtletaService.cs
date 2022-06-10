using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.CORE.ExcecoesPersonalisadas;
using LogTreino.DATA;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Interfaces;

namespace LogTreino.DOMAIN.Services
{
    public class AtletaService : IAtletaService
    {
        private readonly IAtletaRepository _repository;

        public AtletaService(IAtletaRepository repository)
        {
            _repository = repository;
        }
        public Task AlterAtletaAsync(Atleta atleta)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAtletaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InserirAtletaAsync(Atleta_Insert atletaInsert)
        {
            throw new NotImplementedException();
        }

        public async Task<Atleta> ObterAtletaAsync(int id)
        {
            var atleta = await _repository.ObterAtletaAsync(id);
            if(atleta == null)
                throw new ExcecaoPersonalizada("Nenhum atleta encontrado.");

            return atleta;

        }

        public async Task<IEnumerable<Atleta>> ObterAtletasAsync()
        {
            var atletas = await _repository.ObterAtletasAsync();
            if(atletas == null)
                throw new ExcecaoPersonalizada("Nenhum atleta encontrado.");
            
            return atletas;
        }
    }
}