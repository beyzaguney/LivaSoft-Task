using LivaSoft_Task.Context;
using LivaSoft_Task.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivaSoft_Task.Handlers.Commands
{
	public class CreateAccountCommand:IRequest<bool>
	{
        public Guid CustomerId { get; set; }
        public Account Account { get; set; }
        public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, bool>
		{
			private readonly AppDbContext _appDbContext;
			public CreateAccountCommandHandler(AppDbContext appDbContext)
			{
				_appDbContext = appDbContext;
			}

			public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
			{

				_appDbContext.Accounts.Entry(new()
				{
					CustomerId = request.CustomerId
					
				}).State = EntityState.Added;
				await _appDbContext.SaveChangesAsync();

				return true;
			}
		}
	}
}
