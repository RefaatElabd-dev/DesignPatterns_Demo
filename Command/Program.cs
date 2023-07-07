using Command;
using static System.Console;

//var ba = new BankAccount();
//var commands = new List<BankAccountCommand>
//{
//new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100),
//new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 1000)
//};

//WriteLine(ba);

//foreach (var c in commands)
//    c.Call();

//WriteLine(ba);

//foreach (var c in Enumerable.Reverse(commands))
//    c.Undo();

//WriteLine(ba);

var from = new BankAccount();
from.Deposit(100);
var to = new BankAccount();
var mtc = new MoneyTransferCommand(from, to, 1000);
mtc.Call();


// Deposited $100, balance is now 100
// balance: 100
// balance: 0

WriteLine(from);
WriteLine(to);