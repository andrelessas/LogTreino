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
    
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("logtreino/v{version:apiVersion}/aparelhos")]
    public class AparelhoController : ControllerBase
    {
        private readonly IAparelhoService _service;

        public AparelhoController(IAparelhoService service)
        {
            _service = service;
        }
        ///<summary>Obter aparelho por ID</summary>
        ///<param name = "id">ID do aparelho</param>
        ///<returns>Aparelho pesquisado</returns> 
        [ProducesResponseType(typeof(Aparelho_Update),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]  
        [HttpGet("id")]
        public async Task<IActionResult> ObterAparelhoPorID(int id)
        {
            var aparelho = await _service.ObterAparelhoPorIDAsync(id);
            if(aparelho == null)
                return NotFound();
            return Ok(aparelho);
        }

        ///<summary>Obter lista de aparelhos</summary>
        [ProducesResponseType(typeof(Retorno_Paginado),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [HttpGet]
        public async Task<IActionResult> ObterAparelhos([FromQuery]PaginacaoDTO paginacaoDTO)
        {
            var aparelhos = await _service.ObterAparelhosAsync(paginacaoDTO);
            if(aparelhos == null)
                return NotFound();
            return Ok(aparelhos);
        }
        ///<summary>Inserir novo aparelho</summary>
        ///<param name = "Aparelho_Insert">Objeto para insert do aparelho.</param>
        ///<remarks>Exemplo de Request:
        ///
        ///{
        ///     "nome": "Lag Press"
        ///}        
        ///</remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [HttpPost]
        public async Task<IActionResult> InserirAparelhoAsync([FromBody] Aparelho_Insert Aparelho_Insert)
        {
            await _service.InserirAparelhoAsync(Aparelho_Insert);
            return Ok();
        }
        ///<summary>Alterar aparelho</summary>
        ///<param name = "aparelho_Update">Objeto para update do aparelho.</param>
        ///<remarks>Exemplo de Request:
        ///
        ///{
        ///     "id": 0,
        ///     "nome": "string"
        ///}        
        ///</remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [HttpPut]
        public async Task<IActionResult> AlterarAparelhoAsync([FromBody] Aparelho_Update aparelho_Update)
        {
            await _service.AlterarAparelhoAsync(aparelho_Update);
            return Ok();
        }
        ///<summary>Excluir aparelho</summary>
        ///<param name = "id">Id do aparelho.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [HttpDelete]
        public async Task<IActionResult> DeleteAparelhoAsync(int id)
        {
            await _service.ExcluirAparelhoAsync(id);
            return Ok();
        }        
    }
}