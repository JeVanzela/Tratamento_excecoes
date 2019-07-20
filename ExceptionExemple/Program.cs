using System;
using ExceptionExemple.Entities;
using ExceptionExemple.Entities.Exception;
using System.Globalization;

namespace ExceptionExemple
{
    class Program
    {
        static void Main(string[] args)
        {

            int flap = 0;
            char select = ' ';

            //============Cria Conta=============
            Console.WriteLine("Enter account data!");
            Console.Write("Number: ");
            string acc = Console.ReadLine();

            Console.Write("Holder: ");
            string name = Console.ReadLine();

            Console.Write("Initial balance: ");
            string balance = Console.ReadLine();

            Console.Write("Withdraw limit: ");
            string withdrawLimit = Console.ReadLine();

            Account conta = new Account(acc, name, balance, withdrawLimit);

            //inicializo um loop
            do
            {

                //inicializo o tratamento de excecoes
                try
                {

                    Console.WriteLine(conta.ToString());

                    Console.Write("Deposit or withdraw! (d/w): ");
                    select = char.Parse(Console.ReadLine().ToLower());

                    if (select == 'w')
                    {
                        Console.Write("Enter amount for withdraw: ");
                        double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        conta.Withdraw(amount);
                    }

                    else
                    {
                        Console.Write("Enter amount for deposit: ");
                        double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        conta.Deposit(amount);
                    }

                    Console.WriteLine(conta.Balance.ToString("F2", CultureInfo.InvariantCulture));
                }

                //se ouver excecoes===========
                catch (DomainException e)
                {

                    Console.WriteLine("Withdraw error! " + e.Message);

                }
                catch (Exception e)
                {

                    Console.WriteLine("Error! " + e.Message);

                }
                //=============================

                //Pergunto se deseja continuar
                Console.Write("\nYou want to stop the program: yes or no (y/n)");
                select = char.Parse(Console.ReadLine().ToLower());

                if (select == 'y')
                {
                    flap = 1;
                }

                else
                {
                    flap = 0;
                }

            } while (flap == 0);

            Console.ReadKey();
        }
    }
}
