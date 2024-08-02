# Single-Responsibility Principle
The single-responsibility principle (SRP) is a computer programming principle that states that "A module should be responsible to one, and only one, actor."<br/>
As the name indicates, a class should have only one responsibility and this principle ensures that a class only does one thing.

## Example
#### <b>Customer Class</b>
In this example, we have a "Customer" class responsible for managing only customer data such as name, email address, and phone. This class has a single responsibility of handling customer data.
```
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
```

#### <b>BillingService Class</b>
NotificationService class is responsible for sending bills to the customer and notify the due date. Handling billing is the single responsibility of this class.
```
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
```

#### <b>Using the Classes</b>
```
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
```

#### <b>Output:</b>
```
    Bill sent to Sheldon Cooper's email: sheldon_cooper@tbbt.com
    Due date notified to Sheldon Cooper's phone: (234)765-1234
```