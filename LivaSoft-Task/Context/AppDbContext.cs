using LivaSoft_Task.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivaSoft_Task.Context
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions options):base(options) { }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Account> Accounts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			builder.UseInMemoryDatabase("livaDb");
		}
	}
}
