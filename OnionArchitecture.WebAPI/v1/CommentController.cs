using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Service.Features.CommentFeature.Commands;
using OnionArchitecture.Service.Features.CommentFeature.Queries;
using System;
using System.Threading.Tasks;

namespace OnionArchitecture.WebAPI.v1
{
    /// <summary>
    /// This api controller help us to do CRUD on comment table
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiVersion("1")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Inject IMediator Service
        /// </summary>
        /// <param name="mediator"></param>
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// return specific comment
        /// </summary>
        /// <param name="id"> Comment id </param>
        /// <returns></returns>
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(Int64 id)
        {
            return Ok(await _mediator.Send(new GetByIdCommentQuery(id)));
        }

        /// <summary>
        /// return list of all comments in database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCommentQuery()));
        }

        /// <summary>
        /// add new comment  
        /// </summary>
        /// <param name="command">this opbject conrains "comment" object that it is an instance to add database</param>
        /// <returns>return that inserted instance</returns>
        [HttpPost()]
        public async Task<IActionResult> Create(CreateCommentCommand command)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _mediator.Send(command));
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// update comment
        /// </summary>
        /// <param name="id">it is unique id that refer to the specific comment</param>
        /// <param name="command">an instance that would be update</param>
        /// <returns>return updated instance</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Int64 id, UpdateCommentCommand command)
        {
            if (ModelState.IsValid)
            {
                if (id != command.comment.Id)
                {
                    return BadRequest();
                }
                return Ok(await _mediator.Send(command));
            }
            return BadRequest();
        }

        /// <summary>
        /// delete specific comment
        /// </summary>
        /// <param name="id">it is unique id that refer to the specific comment</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            return Ok(await _mediator.Send(new DeleteCommentCommand(id)));
        }
    }
}
