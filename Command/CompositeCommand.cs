namespace Command
{
    public abstract class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
    {
        public virtual void Call()
        {
            ForEach(cmd => cmd.Call());
        }

        public virtual void Undo()
        {
            ForEach((cmd) => cmd.Undo());
        }
    }

    public class MoneyTransferCommand: CompositeBankAccountCommand
    {
        public MoneyTransferCommand(BankAccount from, BankAccount to, int amount)
        {
            AddRange(new List<BankAccountCommand>
            {
                new BankAccountCommand(from, BankAccountCommand.Action.Withdraw, amount),
                new BankAccountCommand(to, BankAccountCommand.Action.Deposit, amount)
            });
        }

        public override void Call()
        {
            var ok = true;
            foreach (var cmd in this)
            {
                if (ok)
                {
                    cmd.Call();
                    ok = cmd.Succeeded;
                }
                else
                {
                    cmd.Succeeded = false;
                }
            }
        }

        public override void Undo()
        {
            foreach (var cmd in this)
            {
                if (cmd.Succeeded)
                {
                    cmd.Call();
                }
                else
                {
                    break;
                }
            }
        }
    }

   
}
