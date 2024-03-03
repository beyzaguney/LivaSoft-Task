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
			private readonly ILogger<CreateAccountCommandHandler> _logger;
			public CreateAccountCommandHandler(AppDbContext appDbContext, ILogger<CreateAccountCommandHandler> logger)
			{
				_appDbContext = appDbContext;
				_logger = logger;
			}

			public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
			{
				try
				{
					//ekleme yaparken json'dan customer nesnesini silmem gerekiyor
					_appDbContext.Accounts.Entry(new()
					{
						CustomerId = request.CustomerId

					}).State = EntityState.Added;
					await _appDbContext.SaveChangesAsync();
					_logger.LogInformation("Hesap eklendi: " + request.Account.Id);

					return true;
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Hesap eklenemedi. {Message}", ex.Message);
					return false;
				}
			}
		}
	}
}
