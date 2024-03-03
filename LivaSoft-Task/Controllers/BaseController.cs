using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LivaSoft_Task.Controllers
{
	public class BaseController : ControllerBase
	{
		protected readonly IMediator Mediatr;
		public BaseController(IMediator mediatr)
		{
			Mediatr = mediatr;
		}
	}
}