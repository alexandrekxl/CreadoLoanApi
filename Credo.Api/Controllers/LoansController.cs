using Credo.Application.Loans.Commands.Create;
using Credo.Application.Loans.Commands.Delete;
using Credo.Application.Loans.Commands.Updare;
using Credo.Application.Loans.Commands.Update;
using Credo.Application.Loans.Queries;
using Credo.Contracts.Loans.Requests;
using Credo.Contracts.Loans.Responses;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Credo.Api.Controllers
{
    [Route("Loans")]
    public class LoansController : ApiController
    {

        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public LoansController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLoanRequest request)
        {
            var command = _mapper.Map<CreateLoanCommand>(request);
            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<BaseCommandResponse>(result)),
                errors => Problem(errors));
        }

        [HttpPut("Id")]
        public async Task<IActionResult> Update(Guid Id, CreateLoanRequest request)
        {
            var updateData = _mapper.Map<CreateLoanCommand>(request);

            var command = new UpdateLoanCommand(Id, updateData);
            var result = await _mediator.Send(command);

            return result.Match(
                createLoanResult => Ok(_mapper.Map<BaseCommandResponse>(createLoanResult)),
                errors => Problem(errors));
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteLoanCommand(Id: id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
