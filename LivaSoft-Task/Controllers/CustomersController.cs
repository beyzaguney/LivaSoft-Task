using LivaSoft_Task.Handlers.Commands;
using LivaSoft_Task.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LivaSoft_Task.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomersController : BaseController
	{
		public CustomersController(IMediator mediatr) : base(mediatr) { }

		//requestleri send edebilmek çin buna ihtiyacýmýz var

		[HttpGet("List")]
		public async Task<IActionResult> List()
		{
			var result = await Mediatr.Send(new CustomerListQuery());
			return Ok( result);
		}
		[HttpPost("Add")]
		public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCommand)
		{
			//mediator send (request adý)
			var result = await Mediatr.Send(createCommand);
			return Created("Customer Created", result);
		}
		
	}
}