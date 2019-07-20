using ExceptionExemple.Entities.Exception;
using System.Globalization;

namespace ExceptionExemple.Entities
{
    class Account
    {

        VectorIsChar IsChar = new VectorIsChar();

        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WhitdrawLimit { get; set; }

        public Account() { }

        public Account(string number, string holder, string balance, string whitdrawLimit)
        {

            //Se number for 0, coloco um numero de conta generico
            Number = (int)IsChar.IsChar(number.ToLower());
            if (Number == 0)
            {
                Number = 1001;
            }

            //Nome
            Holder = holder;

            //Ja o saldo fica 0
            Balance = IsChar.IsChar(balance);

            //E o limite fica valor generico de 100
            WhitdrawLimit = IsChar.IsChar(whitdrawLimit);
            if (WhitdrawLimit == 0)
            {
                WhitdrawLimit = 100.0;
            }
        }

        public void Deposit(double amount)
        {

            if (amount > 0)
            {
                Balance += amount;
            }

            else
            {
                throw new DomainException("This amount is not valid! Withdraw amount: " + amount);

            }
        }

        public void Withdraw(double amount)
        {

            if (amount > 0)
            {

                if (amount <= Balance && amount <= WhitdrawLimit)
                {
                    Balance -= amount;
                }
                else if (amount > WhitdrawLimit)
                {
                    throw new DomainException("This amount exced the withdraw limit!");

                }

                else
                {
                    throw new DomainException("This amount is more than your Balance! Your Balance: " + Balance);

                }
            }

            else
            {
                throw new DomainException("This amount is not valid! Withdraw amount: " + amount);
            }
        }

        public override string ToString()
        {

            return "\nName: " + Holder +
                   " Number Acc: " + Number +
                   " Balance: " + Balance.ToString("F2", CultureInfo.InvariantCulture) +
                   " Withdraw Limit: " + WhitdrawLimit.ToString("F2", CultureInfo.InvariantCulture) +
                   "\n\n";
        }
    }
}
