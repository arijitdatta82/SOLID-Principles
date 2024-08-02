# Liskov substitution principle
Objects of a derived class must be able to replace objects of the parent class without breaking the program. <br/>
If S is a subtype of T, then objects of type T in a program may be replaced with objects of type S without altering any of the desirable properties of that program.

## Example
In the following example, the class "CompanyContractor" does not staisfy the Liskov Substitution Principle as whenever we create an instance of the "CompanyContractor" class and try to replace the "CompanyWorker" base class, we will get an exception when we try to call the "ProcessBonus" function.
```
	public class CompanyWorker
	{
		public virtual void ProcessSalary()
		{
			Console.WriteLine("Salary paid to CompanyWorker");
		}
		
		public virtual void ProcessBonus()
		{
			Console.WriteLine("Bonus paid to CompanyWorker");
		}
	}
	
	public class CompanyEmployee : CompanyWorker
	{
		public override void ProcessSalary()
		{
			Console.WriteLine("Salary paid to CompanyWorker");
		}
		
		public override void ProcessBonus()
		{
			Console.WriteLine("Bonus paid to CompanyWorker");
		}
	}
	
	public class CompanyContractor : CompanyWorker
	{
		public override void ProcessSalary()
		{
			Console.WriteLine("Salary paid to CompanyWorker");
		}
		
		public override void ProcessBonus()
		{
			throw new NotImplementedException();
		}
	}

	public class Program
	{
		public static void Main()
		{
			CompanyWorker employee = new CompanyEmployee();
			employee.ProcessSalary();
			employee.ProcessBonus();
			
			Console.WriteLine("---------------------------------------------------");
			
			CompanyWorker contractor = new CompanyContractor();
			contractor.ProcessSalary();
			contractor.ProcessBonus();
		}
	}
```

Let's fix this in the code below. We have created two separate interfaces "ICompanyWorker" and "ICompanyWorkerWithBonus". Now our classes would implement only the interfaces needed and then the interfaces would be replaceable without any issues.
```
	public class CompanyWorker
	{
		public virtual void ProcessSalary()
		{
			Console.WriteLine("Salary paid to CompanyWorker");
		}
		
		public virtual void ProcessBonus()
		{
			Console.WriteLine("Bonus paid to CompanyWorker");
		}
	}
	
	public interface ICompanyWorker
	{
		void ProcessSalary();
	}
	
	public interface ICompanyWorkerWithBonus
	{
		void ProcessBonus();
	}
	
	public class CompanyEmployee : ICompanyWorker, ICompanyWorkerWithBonus
	{
		public void ProcessSalary()
		{
			Console.WriteLine("Salary paid to CompanyWorker");
		}
		
		public void ProcessBonus()
		{
			Console.WriteLine("Bonus paid to CompanyWorker");
		}
	}
	
	public class CompanyContractor : ICompanyWorker
	{
		public void ProcessSalary()
		{
			Console.WriteLine("Salary paid to CompanyWorker");
		}
	}

	public class Program
	{
		public static void Main()
		{
			ICompanyWorker employee = new CompanyEmployee();
			employee.ProcessSalary();
			
			ICompanyWorkerWithBonus employeeWithBonus = new CompanyEmployee();
			employeeWithBonus.ProcessBonus();
			
			Console.WriteLine("---------------------------------------------------");
			
			ICompanyWorker contractor = new CompanyContractor();
			contractor.ProcessSalary();
		}
	}
```
