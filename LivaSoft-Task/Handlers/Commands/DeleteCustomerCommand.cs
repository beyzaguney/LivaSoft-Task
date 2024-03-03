using LivaSoft_Task.Context;
using LivaSoft_Task.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LivaSoft_Task.Handlers.Commands
{
	public class DeleteCustomerCommand : IRequest<bool>
	{
		public Guid Id { get; set; }
        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
		{
			private readonly AppDbContext _appDbContext;
			private readonly ILogger<DeleteCustomerCommandHandler> _logger;
			public DeleteCustomerCommandHandler(AppDbContext appDbContext, ILogger<DeleteCustomerCommandHandler> logger)
			{
				_appDbContext = appDbContext;
				_logger = logger;
			}

			public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
			{
				try
				{
					var customer = await _appDbContext.Customers
							.Include(c => c.Accounts)
							.FirstOrDefaultAsync(c => c.Id == request.Id); //customer silindiğinde ona ait hesapları silmek için accounts da dahil edildi
					if (customer == null)
					{
						_logger.LogError("Müşteri silinemedi. Belirtilen müşteri bulunamadı.");
						return false;
					}


					foreach (var account in customer.Accounts.ToList())
					{
						_appDbContext.Accounts.Remove(account);
					}

					_appDbContext.Customers.Remove(customer);
					await _appDbContext.SaveChangesAsync();

					_logger.LogInformation("Müşteri silindi: " + customer.Name + " " + customer.Surname);
					return true;
				} 
				catch (Exception ex) 
				{
					_logger.LogError("Müşteri silinemedi. " + ex.Message); 
					return false;
				}
			}
		}
	}
}
