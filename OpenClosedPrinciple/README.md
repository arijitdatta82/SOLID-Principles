# Open-Closed Principle
The Open-Closed Principle (OCP) states that software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification. Such an entity can allow its behavior to be extended without modifying its source code.

## Example
In the following example, the class "LoanCalculator" is used to calculate amount based on simple interest or compound interest calculation formulae. If in future we need to add additional formulae, we will have to modify this class. So, we must test the entire program to make sure that existing behavior is not breaking due to our changes.
```
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
```

The Open-Closed Principle can help us to fix this problem and inheritance is only one way to implement the Open Closed Principle. We need to use an interface or an abstract class in this scenario.
```
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
```