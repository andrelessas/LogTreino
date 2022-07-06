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
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("logtreino/v{version:apiVersion}/medidas")]
    public class MedidasController : ControllerBase
    {
        private readonly IMedidasService _service;

        public MedidasController(IMedidasService service)
        {
            _service = service;
        }

        ///<summary>Exclui medidas</summary>
        ///<param name = "id">id da medida.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> ExcluirMedidaAsync(int id)
        {
            await _service.ExcluirMedidaAsync(id);
            return Ok();
        }

        ///<summary>Alterar medidas</summary>
        ///<param name = "medidasDTO">Objeto para alteração das medidas.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [HttpPut]
        public async Task<IActionResult> AlterarMedidaAsync(MedidasDTO medidasDTO)
        {
            await _service.AlterarMedidaAsync(medidasDTO);
            return Ok();
        }

        ///<summary>Inserir medidas</summary>
        ///<param name = "medidasDTO">Objeto para inserir medida.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> InserirMedidaAsync(MedidasDTO medidasDTO)
        {
            await _service.InserirMedidaAsync(medidasDTO);
            return Ok();
        }   

        ///<summary>Obter medida por ID</summary>
        ///<param name = "id">id da medida.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]     
        [HttpGet("medidaporid")]
        public async Task<IActionResult> ObterMedidaPorIDAsync(int id)
        {
            var medida = await _service.ObterMedidaPorIDAsync(id);
            if(medida == null)
                return NotFound();

            return Ok(medida);
        }        

        ///<summary>Obter medida por por atleta</summary>
        ///<param name = "idAtleta">id do atleta.</param>
        ///<param name = "paginacaoDTO">dados de paginação.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]  
        [HttpGet("medidaporatleta")]
        public async Task<IActionResult> ObterMedidasPorAtletaAsync(int idAtleta, [FromQuery] PaginacaoDTO paginacaoDTO)
        {
            var medidas = await _service.ObterMedidasPorAtletaAsync(idAtleta, paginacaoDTO);
            if(medidas == null)
                return NotFound();

            return Ok(medidas);
        }        
        ///<summary>Obter medida por periodo</summary>
        ///<param name = "medidasAtletaPorPeriodo">objeto para consulta da medida.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]  
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