using System;
			
namespace ArijitDatta.SOLID.Principles.LiskovSubstitutionPrinciple.Noncompliance
{
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
}