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
		private readonly ILogger<CreateCustomerCommandHandler> _logger;

		public CreateCustomerCommandHandler(AppDbContext appDbContext, ILogger<CreateCustomerCommandHandler> logger)
		{
			_appDbContext = appDbContext;
			_logger = logger;
		}

		public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
		{
			try
			{
				_appDbContext.Customers.Entry(new()
				{
					Name = request.Name,
					Surname = request.Surname
				}).State = EntityState.Added;
				await _appDbContext.SaveChangesAsync();
				_logger.LogInformation("Müşteri eklendi: " + request.Name + " " + request.Surname);
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError("Müşteri eklenemedi.", ex.Message);
				return false;
			}
		}
	}
}
