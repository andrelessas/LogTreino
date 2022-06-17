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
        public async Task<IActionResult> ObterAtletasAsync([FromQuery]Paginacao paginacao)
        {
            var atletas = await _service.ObterAtletasAsync(paginacao);
            if (atletas.Dados == null)
                return NotFound();
            
            return Ok(atletas);            
        }

        [HttpGet("id")]
        public async Task<IActionResult> ObterAtletaPorIdAsync(int id)
        {
            var atleta = await _service.ObterAtletaAsync(id);
            if (atleta == null)
                return NotFound();
            
            return Ok(atleta);
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