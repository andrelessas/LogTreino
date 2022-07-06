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
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("logtreino/v{version:apiVersion}/atleta")]
    public class AtletaController : ControllerBase
    {
        private readonly IAtletaService _service;

        public AtletaController(IAtletaService service)
        {
            _service = service;            
        }

        ///<summary>Retorna lista de atletas</summary>
        ///<param name = "paginacaoDTO">Objeto para parametros de paginação.</param>
        [ProducesResponseType(typeof(Retorno_Paginado),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> ObterAtletasAsync([FromQuery]PaginacaoDTO paginacaoDTO)
        {
            var atletas = await _service.ObterAtletasAsync(paginacaoDTO);
            if (atletas.Dados == null)
                return NotFound();
            
            return Ok(atletas);            
        }
        
        ///<summary>Obter Atleta por ID</summary>
        ///<param name = "id">Id do atleta.</param>
        [ProducesResponseType(typeof(Atleta_Insert),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id")]
        public async Task<IActionResult> ObterAtletaPorIdAsync(int id)
        {
            var atleta = await _service.ObterAtletaPorIDAsync(id);
            if (atleta == null)
                return NotFound();
            
            return Ok(atleta);
        }

        ///<summary>Obter Atleta por Nome</summary>
        ///<param name = "nome">Nome do atleta.</param>
        [ProducesResponseType(typeof(Atleta_Insert),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("pornome")]
        public async Task<IActionResult> ObterAtletaPorNome(string nome)
        {
            var atletas = await _service.ObterAtletaPorNome(nome);
            if(atletas == null)
                return NotFound();
            return Ok(atletas);
        }

        ///<summary>Inerir atleta</summary>
        ///<param name = "atleta_Insert">Objeto para insert do atleta.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> InserirAtletaAsync([FromBody]Atleta_Insert atleta_Insert)
        {
            await _service.InserirAtletaAsync(atleta_Insert);
            return Ok();
        }

        ///<summary>Alterar atleta</summary>
        ///<param name = "atleta">Objeto para update do atleta.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> AlterarAtletaAsync([FromBody]Atleta atleta)
        {
            await _service.AlterarAtletaAsync(atleta);
            return Ok();
        }
        ///<summary>Excluir atleta</summary>
        ///<param name = "id">Id do atleta.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("id")]
        public async Task<IActionResult> ExcluirAtletaAsync(int id)
        {
            await _service.DeleteAtletaAsync(id);
            return Ok();
        }
    }
}