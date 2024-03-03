using LivaSoft_Task.Context;
using LivaSoft_Task.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LivaSoft_Task.Handlers.Queries
{
	public class GetAllByCustomerIdQuery : IRequest<ICollection<Account>>
	{
        public Guid? CustomerId { get; set; }
        public GetAllByCustomerIdQuery(Guid id) 
		{
			CustomerId = id;
		}
		public class GetAllByCustomerIdQueryHandler : IRequestHandler<GetAllByCustomerIdQuery, ICollection<Account>>
		{
			private readonly AppDbContext _appDbContext;

			public GetAllByCustomerIdQueryHandler(AppDbContext appDbContext)
			{
				_appDbContext = appDbContext;
			}

			public async Task<ICollection<Account>> Handle(GetAllByCustomerIdQuery request, CancellationToken cancellationToken)
			{
				var query = _appDbContext.Accounts.AsQueryable();

				if (request.CustomerId.HasValue)
				{
					query = query.Where(a => a.CustomerId == request.CustomerId.Value);
				}

				return await query.ToListAsync(cancellationToken);

			}
		}
	}
}