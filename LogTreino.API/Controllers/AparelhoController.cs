using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DOMAIN;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Interfaces;
using LogTreino.DOMAIN.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace LogTreino.API.Controllers
{
    [Route("logtreino/aparelhos")]
    public class AparelhoController : Controller
    {
        private readonly IAparelhoService _service;

        public AparelhoController(IAparelhoService service)
        {
            _service = service;
        }
        [HttpGet("id")]
        public async Task<IActionResult> ObterAparelhoPorID(int id)
        {
            var aparelho = await _service.ObterAparelhoPorIDAsync(id);
            if(aparelho == null)
                return NotFound();
            return Ok(aparelho);
        }
        [HttpGet]
        public async Task<IActionResult> ObterAparelhos(PaginacaoDTO paginacaoDTO)
        {
            var aparelhos = await _service.ObterAparelhosAsync(paginacaoDTO);
            if(aparelhos == null)
                return NotFound();
            return Ok(aparelhos);
        }
        [HttpPost]
        public async Task<IActionResult> InserirAparelhoAsync([FromBody] Aparelho_Insert Aparelho_Insert)
        {
            await _service.InserirAparelhoAsync(Aparelho_Insert);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> AlterarAparelhoAsync([FromBody] Aparelho_Update aparelho_Update)
        {
            await _service.AlterarAparelhoAsync(aparelho_Update);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAparelhoAsync(int id)
        {
            await _service.ExcluirAparelhoAsync(id);
            return Ok();
        }        
    }
}