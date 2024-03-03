namespace LivaSoft_Task.Entities
{
	public class Account
	{
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Balance { get; set; }
        public Customer? Customer { get; set; }
    }
}
