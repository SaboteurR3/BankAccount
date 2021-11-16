using System;
using System.Collections;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // მოხმარებელს შემოაქვს მხოლოდ ანგარიშის ნომერი 
                Console.WriteLine("Greetings (=^_^=)");
                string accountNumber = string.Empty;
                bool account = true;
                while(account)
                {
                    Console.WriteLine("Please enter your AccountNumber");
                    accountNumber = Console.ReadLine();
                    if (accountNumber.Length > 18)
                        Console.WriteLine("AccountNumber digits can't be greater then 18");
                    else if (accountNumber.Length < 9)
                        Console.WriteLine("AccountNumber digits can't be less then 9");
                    else
                        account = false;
                }            
                // მომხმარებელი უთითებს თუ რამდენ ხნიანი ანაბარი სურს იმ შემთხვევაში თუ მონაცემი შეიყვანა არასწორად while ოპერატორის
                // დახმარებით გავიმეორებ კითხვას იქამდე სანამ მომხარებელი სწორად არ შეიყვანს მონაცემს, ამასთან ერთად მივცემ მითითებასაც.
                bool Deposit = true;
                int date = 0;
                while (Deposit)
                {
                    Console.WriteLine("Enter Deposit duration(year): ");
                    int input = int.Parse(Console.ReadLine());
                    if (input >= 6)
                        Console.WriteLine("You can't make a " + input + " year deposit, Max is 5 year deposit!");
                    else if (input > 0 && input <= 5)
                    {
                        date = DateTime.Now.Year + input;
                        Deposit = false;
                    }
                    else
                        Console.WriteLine("The minimum deposit must be 1 year!");
                }
                // კონსტრუქტორს გადავეცი მომხმარებლის მონცაემები და დავბეჭდე
                CDAccount firstUser = new CDAccount(accountNumber, date);
                Console.WriteLine(firstUser.ToString());
                // თანხის შეტანა/გამოტანა
                Console.WriteLine("Do you want to Deposit or Withdraw money?(Yes/No)");
                string answer = Console.ReadLine();
                if (answer.Equals("Yes") || answer.Equals("yes"))
                {
                    bool answerBool = true;
                    while (answerBool)
                    {
                        Console.WriteLine("============================================================================\nChoose A, B or C:\nA)Deposit\nB)Withdraw\nC)Exit\n============================================================================");
                        char depositOrWithdraw = Console.ReadLine()[0];
                        if (depositOrWithdraw.Equals('A') || depositOrWithdraw.Equals('a'))
                        {
                            Console.WriteLine("\nHow much do you want to deposit?");
                            int deposit = int.Parse(Console.ReadLine());
                            firstUser.Deposit(deposit);
                            bool continueDeposit = true;
                            while (continueDeposit)
                            {
                                Console.WriteLine("\nDo you want to make a deposit again?(Yes/No)");
                                string again = Console.ReadLine();
                                if (again.Equals("No") || again.Equals("no"))
                                {
                                    firstUser.ToString();
                                    continueDeposit = false;
                                }
                                if (again.Equals("Yes") || again.Equals("yes"))
                                {
                                    Console.WriteLine("\nHow much do you want to deposit?");
                                    int nextDeposit = int.Parse(Console.ReadLine());
                                    firstUser.Deposit(nextDeposit);
                                }
                            }
                        }
                        else if (depositOrWithdraw.Equals('B') || depositOrWithdraw.Equals('b'))
                        {
                            Console.WriteLine("\nHow much do you want to Withdraw?");
                            int withdraw = int.Parse(Console.ReadLine());
                            firstUser.Withdraw(withdraw);
                            bool continueWithdraw = true;
                            while (continueWithdraw)
                            {
                                Console.WriteLine("\nDo you want to withdraw again?(Yes/No)");
                                string withdrawAgain = Console.ReadLine();
                                if (withdrawAgain.Equals("No") || withdrawAgain.Equals("no"))
                                {
                                    firstUser.ToString();
                                    continueWithdraw = false;
                                }
                                if (withdrawAgain.Equals("Yes") || withdrawAgain.Equals("yes"))
                                {
                                    Console.WriteLine("\nHow much do you want to withdraw?");
                                    int nextWithdraw = int.Parse(Console.ReadLine());
                                    firstUser.Withdraw(nextWithdraw);
                                }
                            }
                        }
                        else if (depositOrWithdraw.Equals('C') || depositOrWithdraw.Equals('c'))
                        {
                            answerBool = false;
                            Console.WriteLine("Bye <3");
                        }
                        else
                            Console.WriteLine("\nIncorrect input");
                    }
                }
                else if (answer.Equals("No") || answer.Equals("no"))
                {
                    Console.WriteLine("Bye <3");
                }
                else
                    Console.WriteLine("I don't get it (0_o)");
                // ანგარიშების სია
                ArrayList accounts = new ArrayList();
                accounts.Add(new CDAccount("accountNumber1", "2.5%", 1000, 2024));
                accounts.Add(new CDAccount("accountNumber2", "2.8%", 5600, 2022));
                accounts.Add(new CDAccount("accountNumber3", "3.2%", 8700, 2025));
                accounts.Add(new CDAccount("accountNumber4", "2.9%", 2450, 2023));
                // ინფორმაცია ბალანსის კლებადობის მიხედვით
                accounts.Sort(new CDAccount());
                Console.WriteLine("\n!!!!!!!!sort by descending accountBalance!!!!!!!!\n");
                foreach (var item in accounts)
                {
                    Console.WriteLine(item);
                }
            }
            catch (FormatException exc)
            {
                Console.WriteLine("Entered format is not correct!", exc.Message);
            }
            catch (OverflowException exc)
            {
                Console.WriteLine("You cant't deposit this amount of money!", exc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}