using System;
			
namespace ArijitDatta.SOLID.Principles.SingleResponsibilityPrinciple
{
	public class Customer
	{
		public string Name { get; set; }
    	public string Email { get; set; }	
		public string Phone { get; set; }	
		public Customer(string name, string email, string phone)
		{
			Name = name;
			Email = email;
			Phone = phone;
		}
	}
	
	public class BillingService
	{
		public void SendBill(Customer customer)
		{
			Console.WriteLine($"Bill sent to {customer.Name}'s email: {customer.Email}");
		}

		public void NotifyDueDate(Customer customer)
		{
			Console.WriteLine($"Due date notified to {customer.Name}'s phone: {customer.Phone}");
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			var customer = new Customer("Sheldon Cooper", "sheldon_cooper@tbbt.com", "(234)765-1234");
        	var billingService = new BillingService();
			
			billingService.SendBill(customer);
			billingService.NotifyDueDate(customer);
		}
	}
}