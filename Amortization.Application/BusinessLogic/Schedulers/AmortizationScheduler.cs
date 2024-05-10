using Amortization.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Application.BusinessLogic.Schedulers
{
    public class AmortizationScheduler
    {
        private readonly Loan Loan;
        public AmortizationScheduler(Loan loan)
        {
            Loan = loan;
            GetPrincipal((double)(loan.LoanAmount), (int)loan.PaymentTerm);
            ConvertPercentage((double)loan.InterestRate);
        }

        public double Principal { get; set; }
        public double InterestRate { get; set; }
        public async Task<List<Schedule>> ProvideSchedule()
        {

            double balance = (double)Loan.LoanAmount;
            double monthlyInterest = 0;
            int numberOfDays = 0;
            DateTime dateHolder_temp = new();
            List<Schedule> schedule = new();
            double BalanceHolder_temp = 0;

            for (int i = 0; i < Loan.PaymentTerm; i++)
            {
                DateTime paymentDate_raw = (DateTime)Loan.PaymentStart;
                DateTime paymentDate = paymentDate_raw.AddMonths(i);
                
                BalanceHolder_temp = balance;
                if (paymentDate.Day != 25)
                {
                    paymentDate = new DateTime(paymentDate.Year, paymentDate.Month, 25);
                }

                if (i == 0)
                {
                    numberOfDays = (paymentDate - (DateTime)Loan.PaymentStart).Days;
                    monthlyInterest = balance * numberOfDays * (InterestRate / 365);
                }
                else
                {
                    numberOfDays = (paymentDate - dateHolder_temp).Days;
                    monthlyInterest = BalanceHolder_temp * numberOfDays * (InterestRate / 365);
                }

                balance -= Principal;
                dateHolder_temp = paymentDate;

                double month_principal = Principal + monthlyInterest;

                Schedule armortization_schedule = new()
                {
                    LoanId = Loan.LoanId,
                    PaymentDate = paymentDate,
                    No_of_Days = numberOfDays,
                    Interest = Math.Round(monthlyInterest, 2),
                    Total = Math.Round(month_principal, 2),
                    Balance = Math.Round(balance, 2),
                    Principal = Math.Round(Principal, 2)
                };

                schedule.Add(armortization_schedule);
            }

            return schedule;
        }

        private void ConvertPercentage(double interest)
        {
             InterestRate = interest / 100;
        }


        private void GetPrincipal(double amount, int term)
        {
            Principal = amount / term;
        }
    }   
     
}
