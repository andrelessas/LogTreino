using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.DTOs.Consultas;
using LogTreino.DOMAIN.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogTreino.API.Controllers
{
    [Route("logtreino/medidas")]
    public class MedidasController : ControllerBase
    {
        private readonly IMedidasService _service;

        public MedidasController(IMedidasService service)
        {
            _service = service;
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirMedidaAsync(int id)
        {
            await _service.ExcluirMedidaAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> AlterarMedidaAsync(int id,MedidasDTO medidasDTO)
        {
            await _service.AlterarMedidaAsync(id,medidasDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> InserirMedidaAsync(MedidasDTO medidasDTO)
        {
            await _service.InserirMedidaAsync(medidasDTO);
            return Ok();
        }        
        [HttpGet("medidaporid")]
        public async Task<IActionResult> ObterMedidaPorIDAsync(int id)
        {
            var medida = await _service.ObterMedidaPorIDAsync(id);
            if(medida == null)
                return NotFound();

            return Ok(medida);
        }        
        [HttpGet("medidaporatleta")]
        public async Task<IActionResult> ObterMedidasPorAtletaAsync(int idAtleta, [FromQuery] PaginacaoDTO paginacaoDTO)
        {
            var medidas = await _service.ObterMedidasPorAtletaAsync(idAtleta, paginacaoDTO);
            if(medidas == null)
                return NotFound();

            return Ok(medidas);
        }        
        [HttpGet("medidaporperiodo")]
        public async Task<IActionResult> ObterMedidasPorPeriodoAsync([FromQuery] MedidasAtletaPorPeriodo medidasAtletaPorPeriodo)
        {
            var medidas = await _service.ObterMedidasPorPeriodoAsync(medidasAtletaPorPeriodo);
            if(medidas == null)
                return NotFound();

            return Ok(medidas);
            // return Ok();
        }        
    }
}