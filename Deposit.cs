using System;
namespace TheFuture
{
    public class Deposit
    {
        public double Total(double amount)
        {
            return amount - CalculateFee(amount);
          
        }
        private double CalculateFee(double amount)
        {
            return amount * 0.001; 
        }
    }
}
