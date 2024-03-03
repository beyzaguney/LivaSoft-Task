using LivaSoft_Task.Handlers.Commands;
using LivaSoft_Task.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LivaSoft_Task.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AccountsController : BaseController
	{
		public AccountsController(IMediator mediatr) : base(mediatr) { }
		[HttpGet("GetAll")]
		public async Task<IActionResult> List()
		{
			var result = await Mediatr.Send(new GetAccountsQuery());
			return Ok(result);
		}
		[HttpGet("GetByCustomerId/{id}")]
		public async Task<IActionResult> GetByCustomerId(Guid id)
		{
			var result = await Mediatr.Send(new GetAllByCustomerIdQuery(id));
			return Ok(result);
		}
		[HttpPost("AddByCustomerId/{id}") ]
		public async Task<IActionResult> Add([FromBody] CreateAccountCommand createCommand)
		{
			var result = await Mediatr.Send(createCommand);
			return Created("Account Created", result);
		}
		[HttpDelete("DeleteById/{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			return Ok(await Mediatr.Send(new DeleteAccountCommand { Id = id }));
		}

	}
}