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
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("logtreino/v{version:apiVersion}/treinodia")]
    public class TreinoDiasController : ControllerBase
    {
        private readonly ITreinoDiaServices _services;

        public TreinoDiasController(ITreinoDiaServices services)
        {
            _services = services;
        }

        ///<summary>Inserir Treino Diario</summary>
        ///<param name = "treinoDiaDTO">objeto para inserir o treino.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> InserirTreinoDiaAsync(TreinoDiaDTO treinoDiaDTO)
        {
            await _services.InserirTreinoDiaAsync(treinoDiaDTO);
            return Ok();
        }

        ///<summary>Alterar Treino Diario</summary>
        ///<param name = "treinoDiaDTO">objeto para alterar o treino.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> AlterarTreinoDiaAsync(TreinoDiaDTO treinoDiaDTO)
        {
            await _services.AlterarTreinoDiaAsync(treinoDiaDTO);
            return Ok();
        }

        ///<summary>Excluir Treino Diario</summary>
        ///<param name = "id">id do treino.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> ExcluirTreinoDiaAsync(int id)
        {
            await _services.ExcluirTreinoDiaAsync(id);
            return Ok();
        }

        ///<summary>Obter Treino por ID</summary>
        ///<param name = "id">id do treino.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id")]
        public async Task<IActionResult> ObterTreinoDiaPorID(int id)
        {
            var treinoDia = await _services.ObterTreinoDiaPorID(id);
            if(treinoDia == null)
                return NotFound();
            return Ok(treinoDia);
        }

        ///<summary>Obter Treino por atleta</summary>
        ///<param name = "idAtleta">id do treino.</param>
        ///<param name = "paginacaoDTO">dados de paginação.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("poratleta")]
        public async Task<IActionResult> ObterTreinosPorAtleta(int idAtleta,[FromQuery] PaginacaoDTO paginacaoDTO)
        {
            var treinoDia = await _services.ObterTreinosPorAtleta(idAtleta,paginacaoDTO);
            if(treinoDia.Dados == null)
                return NotFound();
            return Ok(treinoDia);
        }

        ///<summary>Obter Treino por periodo</summary>
        ///<param name = "dataInicial">data inicial para a pesquisa.</param>
        ///<param name = "dataFinal">data final para a pesquisa.</param>
        ///<param name = "paginacaoDTO">dados de paginação.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]  
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