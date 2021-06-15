using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Service;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Controllers
{

    /// <summary>
    /// Visitor controller
    /// </summary>
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class JumpTheQueueController : ControllerBase
    {
        public IJumpTheQueueService _JumpTheQueueService;

        public JumpTheQueueController(IJumpTheQueueService JumpTheQueueService)
        {
            _JumpTheQueueService = JumpTheQueueService;
        }

        /// <summary>
        /// Creates a new Visitor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Visitor), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateVisitor(VisitorDto visitorDto)
        {
            Devon4NetLogger.Debug("Executing GetTodo from controller TodoController");
            var result = await _JumpTheQueueService.CreateVisitor(visitorDto).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status201Created, result);
        }
    }
}
