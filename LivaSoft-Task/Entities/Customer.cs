namespace LivaSoft_Task.Entities
{
	public class Customer
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Account> Accounts { get; set; }
	}
}
