using LivaSoft_Task.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LivaSoft_Task.Handlers.Commands;

public class CreateCustomerCommand:IRequest<bool>
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
	{
		private readonly AppDbContext _appDbContext;

		public CreateCustomerCommandHandler(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
		{
			_appDbContext.Customers.Entry(new()
			{
				Name = request.Name,
				Surname = request.Surname
			}).State=EntityState.Added;
			await _appDbContext.SaveChangesAsync();
			return true;
		}
	}
}
