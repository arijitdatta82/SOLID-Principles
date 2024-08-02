using System;
			
namespace ArijitDatta.SOLID.Principles.InterfaceSegregationPrinciple
{
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
	

	
	public class Program
	{
		public static void Main()
		{
			var mobileCustomer = new MobileCustomer();
			mobileCustomer.ShowPhoneNumber();
			
			Console.WriteLine("---------------------------------------------------------");
			
			var allCustomer = new AllServiceCustomer();
			allCustomer.ShowTVChannels();
			allCustomer.ShowDataPackage();
			allCustomer.ShowPhoneNumber();
		}
	}
}