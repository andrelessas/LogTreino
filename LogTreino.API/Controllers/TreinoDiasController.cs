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
        public async Task<IActionResult> InserirTreinoDia(TreinoDiaDTO treinoDiaDTO)
        {
            await _services.InserirTreinoDiaAsync(treinoDiaDTO);
            return Ok();
        }
    }
}