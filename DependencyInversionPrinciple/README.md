# Dependency Inversion Principle
The Dependency Inversion Principle states that high level modules should not depend upon low level modules. This allows for more flexible and decoupled code, making it easier to change implementations without affecting other parts of the codebase. 

## Example

The example below does not follow the “Dependency Inversion Principle” as the higher-level class "Customer" is directly dependent upon the lower-level "DataSaver" class. If in future we need to save data to a different database, this code will not support that.
```
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
```

We can fix this by adding an interface "IDataSaver". Then "RelationalDBDataSaver" class can implement the interface. When we need another class to save the data to NoSQL database, we simply create another class "" which implements the same interface. 
```
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
```