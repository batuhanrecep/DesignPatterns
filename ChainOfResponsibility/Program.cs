using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Chain of Responsibility design pattern allows a request to pass through a chain of handlers,
            //where each handler decides either to process the request or pass it to the next handler in the chain,
            //enabling flexible and dynamic processing of requests without tightly coupling the sender and receiver.


            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense {Detail = "Training", Amount = 1918};
            manager.HandleExpense(expense);

            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }

    }

    class Manager:ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if (Successor!=null)
            {
                Successor.HandleExpense(expense);
            }
            
        }
    }
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=1000)
            {
                Console.WriteLine("Vice President handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
}
