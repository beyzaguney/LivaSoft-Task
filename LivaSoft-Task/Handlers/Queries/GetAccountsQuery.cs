using LivaSoft_Task.Context;
using LivaSoft_Task.Entities;
using MediatR;

namespace LivaSoft_Task.Handlers.Queries
{
	public class GetAccountsQuery:IRequest<ICollection<Account>>
	{
		public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, ICollection<Account>>
		{
			private readonly AppDbContext _appDbContext;

			public GetAccountsQueryHandler(AppDbContext appDbContext)
			{
				_appDbContext = appDbContext;
			}

			public async Task<ICollection<Account>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
			{
				return _appDbContext.Accounts.ToList();
			}
		}
	}
}
