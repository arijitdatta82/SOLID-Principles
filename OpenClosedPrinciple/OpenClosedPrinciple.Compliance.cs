using System;
			
namespace ArijitDatta.SOLID.Principles.OpenClosedPrinciple.Compliance
{
	public interface ILoanCalculator
    {
        double CalculateAmount();
    }
	
	public class SimpleLoanCalculator : ILoanCalculator
	{
		public double Principal { get; set; }
		public double Rate { get; set; } 
		public int Time { get; set; }
		
		public double CalculateAmount()
		{
			double rt = Rate / 100;
			double amount = Principal * (1 + rt * Time);
			return amount;
		}
	}
	
	public class CompoundLoanCalculator : ILoanCalculator
	{
		public double Principal { get; set; }
		public double Rate { get; set; } 
		public int Time { get; set; }
		
		public double CalculateAmount()
		{
			double rt = Rate / 100;
			double interest = Principal * Math.Pow((1 + (rt / Time)), (Time * Time));
			double amount = Principal + interest;
			return amount;
		}
	}
	
	public class AccruedLoanCalculator : ILoanCalculator
	{
		public double LoanAmount { get; set; }
		public double Rate { get; set; } 
		public int Days { get; set; }
		
		public double CalculateAmount()
		{
			double rt = Rate / 100;
			double interest = rt * (Days / 365) * LoanAmount;
			double amount = LoanAmount + interest;
			return amount;
		}
	}	
	
	public class Program
	{
		public static void Main()
		{
			ILoanCalculator loan = new SimpleLoanCalculator() { Principal = 100000, Rate = 5.5, Time = 5 };
			var amount = loan.CalculateAmount();
			Console.WriteLine($"Total Amount $ {amount} is calculated with Simple Interest!");
			Console.WriteLine("---------------------------------------------------------");
			
			ILoanCalculator loan2 = new CompoundLoanCalculator() { Principal = 100000, Rate = 5.5, Time = 5 };
			var amount2 = loan2.CalculateAmount();
			Console.WriteLine($"Total Amount $ {amount2} is calculated with Compound Interest!");
			Console.WriteLine("---------------------------------------------------------");
			
			ILoanCalculator loan3 = new AccruedLoanCalculator() { LoanAmount = 100000, Rate = 5.5, Days = 445 };
			var amount3 = loan3.CalculateAmount();
			Console.WriteLine($"Total Amount $ {amount3} is calculated with Accrued Interest!");
		}
	}
}