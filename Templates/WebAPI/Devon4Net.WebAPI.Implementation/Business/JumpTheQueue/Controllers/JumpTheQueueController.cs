using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Cmd;
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
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class JumpTheQueueController : ControllerBase
    {
        public IJumpTheQueueService _JumpTheQueueService;

        public JumpTheQueueController(IJumpTheQueueService JumpTheQueueService)
        {
            _JumpTheQueueService = JumpTheQueueService;
        }
        /// <summary>
        /// Gets the entire list of Visitors
        /// </summary>
        /// <returns></returns>
        // [HttpGet]
        [HttpGet]
        [Route("GetVisitors")]
        [ProducesResponseType(typeof(List<VisitorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetVisitors()
        {
            Devon4NetLogger.Debug("Executing GetVisitors from controller JumpTheQueueController");
            return Ok(await _JumpTheQueueService.GetVisitors().ConfigureAwait(false));
        }


        /// <summary>
        /// Creates a new Visitor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateVisitor")]
        [ProducesResponseType(typeof(Visitor), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateVisitor([FromBody] VisitorDto visitorDto)
        {
            Devon4NetLogger.Debug("Executing GetTodo from controller TodoController");
            var result = await _JumpTheQueueService.CreateVisitor(visitorDto).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status201Created, result);
        }


        /// <summary>
        /// Deletes the Visitor provided by the id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteVisitor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteVisitor(int visitorId)
        {
            Devon4NetLogger.Debug("Executing GetTodo from controller TodoController");
            await _JumpTheQueueService.DeleteVisitorById(visitorId).ConfigureAwait(false);
            return Ok();
        }
     
        /// <summary>
        /// Create a new AccessCode
        /// </summary>
        [HttpPost]
        [Route("CreateAccessCode")]
        [ProducesResponseType(typeof(AccessCode), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateAccessCode([FromBody] AccessCodeCmd accessCodeDto)
        {
            Devon4NetLogger.Debug("Executing GetTodo from controller TodoController");
            var result = await _JumpTheQueueService.CreateAccessCode(accessCodeDto).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Deletes the Visitor provided by the id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteAccessCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAccessCode(int accessCodeId)
        {
            Devon4NetLogger.Debug("Executing GetTodo from controller TodoController");
            await _JumpTheQueueService.DeleteAccessCodeById(accessCodeId).ConfigureAwait(false);
            return Ok();
        }
    }
}
