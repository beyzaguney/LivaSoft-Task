using LivaSoft_Task.Context;
using LivaSoft_Task.Entities;
using MediatR;

namespace LivaSoft_Task.Handlers.Commands
{
	public class DeleteAccountCommandRequest:IRequest<bool>
	{
        public Guid Id { get; set; }
        public Account Account { get; set; }
		public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommandRequest, bool>
		{
			private readonly AppDbContext _appDbContext;
			public DeleteAccountCommandHandler(AppDbContext appDbContext)
			{
				_appDbContext = appDbContext;
			}

			public async Task<bool> Handle(DeleteAccountCommandRequest request, CancellationToken cancellationToken)
			{
				var account = await _appDbContext.Accounts.FindAsync(request.Id);
				if (account != null)
				{
					_appDbContext.Accounts.Remove(account);
					await _appDbContext.SaveChangesAsync();
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}
}
