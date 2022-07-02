using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DOMAIN.DTOs;
using LogTreino.DOMAIN.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogTreino.API.Controllers
{
    [Route("logtreino/treinodia")]
    public class TreinoDiasController : ControllerBase
    {
        private readonly ITreinoDiaServices _services;

        public TreinoDiasController(ITreinoDiaServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> InserirTreinoDiaAsync(TreinoDiaDTO treinoDiaDTO)
        {
            await _services.InserirTreinoDiaAsync(treinoDiaDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AlterarTreinoDiaAsync(TreinoDiaDTO treinoDiaDTO)
        {
            await _services.AlterarTreinoDiaAsync(treinoDiaDTO);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirTreinoDiaAsync(int id)
        {
            await _services.ExcluirTreinoDiaAsync(id);
            return Ok();
        }

        [HttpGet("id")]
        public async Task<IActionResult> ObterTreinoDiaPorID(int id)
        {
            var treinoDia = await _services.ObterTreinoDiaPorID(id);
            if(treinoDia == null)
                return NotFound();
            return Ok(treinoDia);
        }

        [HttpGet("poratleta")]
        public async Task<IActionResult> ObterTreinosPorAtleta(int idAtleta,[FromQuery] PaginacaoDTO paginacaoDTO)
        {
            var treinoDia = await _services.ObterTreinosPorAtleta(idAtleta,paginacaoDTO);
            if(treinoDia.Dados == null)
                return NotFound();
            return Ok(treinoDia);
        }
        [HttpGet("porperiodo")]
        public async Task<IActionResult> ObterTreinosPorData(DateTime dataInicial,DateTime dataFinal, [FromQuery] PaginacaoDTO paginacaoDTO)
        {
            var treinoDias = await _services.ObterTreinosPorPeriodo(dataInicial,dataFinal,paginacaoDTO);
            if(treinoDias.Dados == null)
                return NotFound();
            return Ok(treinoDias);
        }
    }
}