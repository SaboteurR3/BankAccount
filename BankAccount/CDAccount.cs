using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class CDAccount : SavingAccount, IComparer
    {
        private int depositTerm; // ანაბრის ვადა.

        // უპარამეტრო კონსტრუქტორი 
        public CDAccount() { }
        // პარამეტრებიანი კონსტრუქტორი 
        public CDAccount(string accountNumber, int depositTerm)
            : base(accountNumber)
        {
            this.depositTerm = depositTerm;
        }
        // გადავტვირთული პარამეტრებიანი კონსტრუქტორი
        public CDAccount(string accountNumber, string interestRate, int accountBalance, int depositTerm)
            : base(accountNumber, interestRate, accountBalance)
        {
            this.depositTerm = depositTerm;
        }
        public int DepositTerm
        {
            get { return depositTerm; }
            set { depositTerm = value; }
        }
        // მეთოდი თანხის შესატანად
        public override void Deposit(int yourDeposit)
        {
            accountBalance += yourDeposit;
            Console.WriteLine("Your current balance is: " + accountBalance + "$");
        }
        // მეთოდი თანხის გასატანად
        public override void Withdraw(int yourwithdraw)
        {
            accountBalance -= yourwithdraw;
            if (accountBalance < 0)
                Console.WriteLine("You can't withdraw! You need another " + (-1 * (accountBalance)) + "$ to withdraw " + yourwithdraw + "$");
            else
                Console.WriteLine("Your current balance is: " + accountBalance + "$");
        }
        // ToString() მომხმარებელზე ინფორმაციის მისაღებად ტექსტის სახით
        public override string ToString()
        {
            return "============================================================================\n"
                + "AccountNumber: " + accountNumber + "\nInterestRate: " + interestRate
                + "\nAccountBalance: " + accountBalance + "\nDeposit term until: " + depositTerm +
                "\n============================================================================";
        }
        // IComparer ინტერფეისის "Compare" მეთოდი
        public int Compare(object x, object y)
        {
            CDAccount firstObject = x as CDAccount;
            CDAccount secondObject = y as CDAccount;
            if (firstObject.accountBalance == secondObject.accountBalance)
                return 0;
            else if (firstObject.accountBalance < secondObject.accountBalance)
                return 1;
            else
                return -1;
        }
    }
}