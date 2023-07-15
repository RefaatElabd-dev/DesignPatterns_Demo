using Momento;
using static System.Console;

var ba = new BankAccount(100);
ba.Deposit(50);
ba.Deposit(25);
WriteLine(ba);

ba.Undo();
WriteLine($"Undo 1: {ba}");
ba.Undo();
WriteLine($"Undo 2: {ba}");
ba.Redo();
WriteLine($"Redo 2: {ba}");