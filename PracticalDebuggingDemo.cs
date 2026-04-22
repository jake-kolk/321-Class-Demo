using System;
using System.Collections.Generic;

class Program
{
    static List<double> CalculateMonthlyPayments(double loanAmount, double annualRate, int months)
    {
        var payments = new List<double>();
        double monthlyRate = annualRate / 12;

        for (int month = 1; month <= months; month++)
        {
            double payment = loanAmount * monthlyRate / (1 - Math.Pow(1 + monthlyRate, -months));
            double interest = loanAmount * monthlyRate;
            double principal = payment - interest;

            loanAmount -= principal;
            payments.Add(Math.Round(payment, 2));
        }

        return payments;
    }

    static double GetRemainingBalance(List<double> payments, double loanAmount, double annualRate)
    {
        double monthlyRate = annualRate / 12;
        double balance = loanAmount;

        foreach (double payment in payments)
        {
            double interest = balance * monthlyRate;
            balance -= (payment - interest);
        }

        return Math.Round(balance, 2);
    }

    static void Main()
    {
        double loan = 10000;
        double rate = 0.05;
        int months = 12;

        var payments = CalculateMonthlyPayments(loan, rate, months);

        Console.WriteLine("Monthly Payments:");
        for (int i = 0; i < payments.Count; i++)
            Console.WriteLine($"  Month {i + 1}: ${payments[i]}");

        double remaining = GetRemainingBalance(payments, loan, rate);
        Console.WriteLine($"\nRemaining balance after all payments: ${remaining}");
        Console.WriteLine($"Expected remaining balance: $0.00");
    }
}
