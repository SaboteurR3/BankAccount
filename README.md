# BankAccount
The company creates software for banks and financial organizations. The company is currently working on a new system for managing customer accounts.
One of my tasks was to create a class that reflected the deposit. The base class object has the following fields:

• Account number
• Interest rate
• Account balance

I also created a Deposit Certificate (CD) derived class with the following data:

• Account number
• Interest rate
• Account balance
• Deposit term

I added the methods Deposit() and Withdraw(), as well as ToString() to get information in the form of text.
To test classes: Customer enters information,
On CDAccount - I created an object, entered the information provided by the user and extracted the object information. Customers should also be able to
Deposit and withdraw money from the account using the appropriate methods Deposit() and Withdraw()
(I took into account the user balance).
I created a ArrayList of accounts where I saved all the accounts, and displayed their information in descending order (via Icomparer interface).
