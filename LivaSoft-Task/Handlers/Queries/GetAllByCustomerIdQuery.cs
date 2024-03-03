using LivaSoft_Task.Context;
using LivaSoft_Task.Entities;
using MediatR;

namespace LivaSoft_Task.Handlers.Queries
{
	public class GetAllByCustomerIdQuery : IRequest<ICollection<Account>>
	{
        public Guid Id { get; set; }
        public GetAllByCustomerIdQuery(Guid id) 
		{
			Id = id;
		}
		//public class GetAllByCustomerIdQueryHandler : IRequestHandler<GetAllByCustomerIdQuery, ICollection<Account>>
		//{
		//	private readonly AppDbContext _appDbContext;

		//	public GetAllByCustomerIdQueryHandler(AppDbContext appDbContext)
		//	{
		//		_appDbContext = appDbContext;
		//	}

		//	//public async Task<ICollection<Account>> Handle(GetAllByCustomerIdQuery request, CancellationToken cancellationToken)
		//	//{
				
		//	//}
		//}
	}
}