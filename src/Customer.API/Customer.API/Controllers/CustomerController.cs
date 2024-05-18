using Customer.Application.Feature.Customer.Commands;
using Customer.Application.Feature.Customer.Queries;
using Customer.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[Route("api/[controller]/[Action]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "Get")]
    [ProducesResponseType(typeof(GetCustomerResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get(Guid id)
    {
        var query = new GetCustomerQuery(id);
        var result = await _mediator.Send(query);

        if(result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet(Name = "List")]
    [ProducesResponseType(typeof(IEnumerable<GetCustomerResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> List()
    {
        var query = new ListCustomersQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost(Name = "Create")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> Create([FromBody] CreateCustomerRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new CreateCustomerCommand(request);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = result.Id}, request);
    }

    [HttpPut(Name = "Update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateStreamer([FromBody] UpdateCustomerRequest request)
    {
        var command = new UpdateCustomerCommand(request);
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
    }

    [HttpDelete("{id}", Name = "DeleteStreamer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteStreamer(Guid id)
    {
        var command = new DeleteCustomerCommand(id);
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
    }

}