using System;
			
namespace ArijitDatta.SOLID.Principles.OpenClosedPrinciple.Noncompliance
{
	public class LoanCalculator
	{
		public double Principal { get; set; }
		public double Rate { get; set; } 
		public int Time { get; set; }
		public double CalculateAmount(string interestType)
		{
			double? amount = null;
			if (interestType == "Simple")
			{
				double rt = Rate / 100;
				amount = Principal * (1 + rt * Time);
			}
			else 
			{
				double rt = Rate / 100;
				double interest = Principal * Math.Pow((1 + (rt / Time)), (Time * Time));
				amount = Principal + interest;
			}
			
			return amount.Value;
		}
	}
	

	public class Program
	{
		public static void Main()
		{
			LoanCalculator loan = new LoanCalculator() { Principal = 100000, Rate = 5.5, Time = 5 };
			var amount = loan.CalculateAmount("Simple");
			Console.WriteLine($"Total Amount $ {amount} is calculated with Simple Interest!");
			Console.WriteLine("---------------------------------------------------------");
			var amount2 = loan.CalculateAmount("Compound");
			Console.WriteLine($"Total Amount $ {amount2} is calculated with Compound Interest!");
			
		}
	}
}