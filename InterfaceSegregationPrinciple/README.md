# Interface Segregation Principle
The Interface Segregation Principle (ISP) states that no code should be forced to depend on methods it does not use. It splits interfaces that are very large into smaller and more specific ones so that clients will only have to know about the methods that are of interest to them. It is intended to keep a system decoupled and thus easier to refactor, change, and redeploy.


## Example
Let's suppose there is a company that support three line of business. 
1. Cable TV
2. Mobile
3. Internet

Each line of business has their own unique attribute. <br/>
In this example, we are creating 3 interfaces ICableCustomer, IMobileCustomer and IInternetCustomer. Each interface represents the customer of respective line of business. Each interface contains attributes that is relevant only for that line of business.
```
	public interface ICableCustomer
    {
        void ShowTVChannels();
    }
	
	public interface IMobileCustomer
    {
        void ShowPhoneNumber();
    }
	
	public interface IInternetCustomer
    {
        void ShowDataPackage();
    }
	
	public class MobileCustomer : IMobileCustomer
	{
		public void ShowPhoneNumber()
		{
			Console.WriteLine("Customer's Phone Number: 321-123-1234");
		}
	}
	
	public class AllServiceCustomer : IMobileCustomer, IInternetCustomer, ICableCustomer
	{

		public void ShowTVChannels()
		{
			Console.WriteLine("Customer's TVChannels: HBO, Disney, CNBC");
		}
		
		public void ShowDataPackage()
		{
			Console.WriteLine("Customer's Data Package: 128 GB");
		}
		
		public void ShowPhoneNumber()
		{
			Console.WriteLine("Customer's Phone Number: 321-576-0987");
		}
	}
```
