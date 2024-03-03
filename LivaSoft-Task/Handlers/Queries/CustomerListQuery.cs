using LivaSoft_Task.Context;
using LivaSoft_Task.Entities;
using MediatR;

namespace LivaSoft_Task.Handlers.Queries
{

	//clasın adı : Request olduğunu belirtiyoruz <Geri dönüş değeri>
	public class CustomerListQuery:IRequest<ICollection<Customer>>
	{
		//Yukarıdaki class mediatra send edildiğinde çalışan class burası
		//classın adı : Bir request yakalayıcı olduğunu belirtiyoruz <Hangi request çalıştırıldığında burası çalışacak onu belirtiyoruz, geri dönüş değeri >
		//Buradaki geri gönüş değeri ve yukarıdaki geri dönüş değeri aynı olmalı
		public class CustomerListQueryHandler : IRequestHandler<CustomerListQuery, ICollection<Customer>>
		{
			private readonly AppDbContext _appDbContext;

			public CustomerListQueryHandler(AppDbContext appDbContext)
			{
				_appDbContext = appDbContext;
			}
			public async Task<ICollection<Customer>> Handle(CustomerListQuery request, CancellationToken cancellationToken)
			{
				return _appDbContext.Customers.ToList();
			}
		}
	}
}
