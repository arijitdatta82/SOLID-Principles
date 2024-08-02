using System;
			
namespace ArijitDatta.SOLID.Principles.DependencyInversionPrinciple.Compliance
{
	public interface IDataSaver
	{
		void SaveData(string name);
	}
	
	public class RelationalDBDataSaver : IDataSaver
	{
		public void SaveData(string name)
		{
			Console.WriteLine("Customer Name:" + name);
			Console.WriteLine("Customer's data saved to relational database.");
		}
	}
	
	public class NoSqlDataSaver : IDataSaver
	{
		public void SaveData(string name)
		{
			Console.WriteLine("Customer Name:" + name);
			Console.WriteLine("Customer's data saved to NoSql database.");
		}
	}
	
	public class Customer
	{
		string _name;
		IDataSaver _dataSaver;
		public Customer(string name, IDataSaver dataSaver)
		{
			_name = name;
			_dataSaver = dataSaver;
		}
		
		public void SaveCustomerData()
		{
			_dataSaver.SaveData(_name);
		}
	}
	

	
	public class Program
	{
		public static void Main()
		{
			var customer = new Customer("John Snow", new RelationalDBDataSaver());
			customer.SaveCustomerData();
			Console.WriteLine("---------------------------------------------------------");
			var customer1 = new Customer("Arya Stark", new NoSqlDataSaver());
			customer1.SaveCustomerData();
		}
	}
}