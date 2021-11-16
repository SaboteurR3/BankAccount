using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class SavingAccount
    {
        internal protected string accountNumber;  // ანგარიშის ნომერი
        internal protected string interestRate = "3%"; // საპროცენტო განაკვეთი 
        internal protected int accountBalance; // ანგარიშის ბალანსი

        // უპარამეტრო კონსტრუქტორი
        public SavingAccount() { }
        // პარამეტრიანი კონსტრუქტორი 
        public SavingAccount(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }
        // გადავტვირთე პარამეტრებიანი კონსტრუქტორი, როემლიც დამჭირდება მოგვიანებით ანგარიშების სიისთვის 
        public SavingAccount(string accountNumber, string interestRate, int accountBalance)
        {
            this.accountNumber = accountNumber;
            this.interestRate = interestRate;
            this.accountBalance = accountBalance;
        }
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public string InterestRate
        {
            get { return interestRate; }
        }
        // მეთოდი თანხის შესატანად
        public virtual void Deposit(int yourDeposit)
        {
            accountBalance += yourDeposit;
            Console.WriteLine("Your current balance is: " + accountBalance + "$");
        }
        // მეთოდი თანხის გასატანად
        public virtual void Withdraw(int yourwithdraw)
        {
            accountBalance -= yourwithdraw;
            if (accountBalance < 0)
            {
                Console.WriteLine("You can't withdraw! You need another " + (-1 * (accountBalance)) + "$ to withdraw " + yourwithdraw + "$");
                accountBalance += yourwithdraw;
            }
            else
                Console.WriteLine("Your current balance is: " + accountBalance + "$");
        }
    }
}