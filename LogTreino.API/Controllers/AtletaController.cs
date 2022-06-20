using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DATA;
using LogTreino.DOMAIN;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Interfaces;
using LogTreino.DOMAIN.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace LogTreino.API.Controllers
{
    [Route("logtreino/atleta")]
    public class AtletaController : ControllerBase
    {
        private readonly IAtletaService _service;

        public AtletaController(IAtletaService service)
        {
            _service = service;            
        }

        [HttpGet]
        public async Task<IActionResult> ObterAtletasAsync([FromQuery]PaginacaoDTO paginacaoDTO)
        {
            var atletas = await _service.ObterAtletasAsync(paginacaoDTO);
            if (atletas.Dados == null)
                return NotFound();
            
            return Ok(atletas);            
        }

        [HttpGet("id")]
        public async Task<IActionResult> ObterAtletaPorIdAsync(int id)
        {
            var atleta = await _service.ObterAtletaPorIDAsync(id);
            if (atleta == null)
                return NotFound();
            
            return Ok(atleta);
        }
        [HttpGet("pornome")]
        public async Task<IActionResult> ObterAtletaPorNome(string nome)
        {
            var atletas = await _service.ObterAtletaPorNome(nome);
            if(atletas == null)
                return NotFound();
            return Ok(atletas);
        }

        [HttpPost]
        public async Task<IActionResult> InserirAtletaAsync([FromBody]Atleta_Insert atleta_Insert)
        {
            await _service.InserirAtletaAsync(atleta_Insert);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AlterarAtletaAsync([FromBody]Atleta atleta)
        {
            await _service.AlterarAtletaAsync(atleta);
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> ExcluirAtletaAsync(int id)
        {
            await _service.DeleteAtletaAsync(id);
            return Ok();
        }
    }
}