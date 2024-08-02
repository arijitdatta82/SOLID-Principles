using System;
			
namespace ArijitDatta.SOLID.Principles.LiskovSubstitutionPrinciple.Compliance
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
}