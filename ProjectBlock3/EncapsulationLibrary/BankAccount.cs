namespace EncapsulationLibrary
{
    public class BankAccount
    {
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной;");
            balance += amount;
        }

        public void Whithdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной;");
            if (amount > balance)
                throw new InvalidOperationException("Недостаточно средств на счете");

            balance -= amount;
        }
    }
}
