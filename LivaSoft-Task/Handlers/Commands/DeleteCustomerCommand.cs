using LivaSoft_Task.Context;
using LivaSoft_Task.Entities;
using MediatR;

namespace LivaSoft_Task.Handlers.Commands
{
	public class DeleteCustomerCommand : IRequest<bool>
	{
		public Guid Id { get; set; }
        public Customer Customer { get; set; }
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
				var customer = await _appDbContext.Customers.FindAsync(request.Id);
				if (customer != null)
				{
					_appDbContext.Customers.Remove(customer);
					await _appDbContext.SaveChangesAsync();
					_logger.LogInformation("Müşteri silindi: " + customer.Name+ " "+customer.Surname);
					return true;
				}
				else
				{
					_logger.LogError("Müşteri silinemedi. Belirtilen müşteri bulunamadı.");
					return false;
				}
			}
		}
	}
}
