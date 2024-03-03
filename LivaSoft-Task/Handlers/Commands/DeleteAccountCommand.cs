using LivaSoft_Task.Context;
using LivaSoft_Task.Entities;
using MediatR;

namespace LivaSoft_Task.Handlers.Commands
{
	public class DeleteAccountCommand:IRequest<bool>
	{
        public Guid Id { get; set; }
        public Account Account { get; set; }
		public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, bool>
		{
			private readonly AppDbContext _appDbContext;
			private readonly ILogger<DeleteAccountCommandHandler> _logger;
			public DeleteAccountCommandHandler(AppDbContext appDbContext, ILogger<DeleteAccountCommandHandler> logger)
			{
				_appDbContext = appDbContext;
				_logger = logger;
			}

			public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
			{
				var account = await _appDbContext.Accounts.FindAsync(request.Id);
				if (account != null)
				{
					_appDbContext.Accounts.Remove(account);
					await _appDbContext.SaveChangesAsync();
					_logger.LogInformation("Hesap silindi: " + account.Id);
					return true;
				}
				else
				{
					_logger.LogError("Hesap silinemedi. Belirtilen hesap bulunamadı.");
					return false;
				}
			}
		}
	}
}
