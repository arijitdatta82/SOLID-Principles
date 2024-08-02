using System;
			
namespace ArijitDatta.SOLID.Principles.DependencyInversionPrinciple.Noncompliance
{
	public class DataSaver
	{
		public void SaveData(string name)
		{
			Console.WriteLine("Customer Name:" + name);
			Console.WriteLine("Customer's data saved to relational database.");
		}
	}
	
	public class Customer
	{
		string _name;
		public Customer(string name)
		{
			_name = name;
		}
		
		public void SaveCustomerData()
		{
			DataSaver dataSaver = new DataSaver();
			dataSaver.SaveData(_name);
		}
	}
	

	
	public class Program
	{
		public static void Main()
		{
			var customer = new Customer("John Snow");
			customer.SaveCustomerData();
		}
	}
}