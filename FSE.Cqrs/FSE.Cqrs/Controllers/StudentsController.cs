using FSE.Cqrs.CQRS.Commands;
using FSE.Cqrs.CQRS.Handlers;
using FSE.Cqrs.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FSE.Cqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly GetStudentByIdQueryHandler getStudentByIdQueryHandler;
        //private readonly GetStudentsQueryHandler getStudentsQueryHandler;
        //private readonly CreateStudentCommandHandler createStudentCommandHandler;
        //private readonly RemoveStudentCommandHandler removeStudentCommandHandler;
        //private readonly UpdateStudentCommandHandler updateStudentCommandHandler;

        //public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        //{
        //    this.getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        //    this.getStudentsQueryHandler = getStudentsQueryHandler;
        //    this.createStudentCommandHandler = createStudentCommandHandler;
        //    this.removeStudentCommandHandler = removeStudentCommandHandler;
        //    this.updateStudentCommandHandler = updateStudentCommandHandler;
        //}

        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Created("", command.Name);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
