using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The Bridge design pattern decouples an abstraction from its implementation, allowing them to vary independently,
            // which promotes flexibility and scalability by enabling the separation of concerns between the abstraction and its actual implementation.


            CustomerManager customerManager =new CustomerManager();
            customerManager.MessageSenderBase = new MailSender();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.UpdateCustomer();





            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        public abstract void Send(Body body);
        //Without bridge
        //public void SendSms()
        //{

        //}
        //public void SendEmail()
        //{

        //}
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    class MailSender: MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via MailSender", body.Title);
        }
    }
    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);
        }
    }
    //...

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            //Worst way to do 
            //SmsSender smsSender = new SmsSender();
            //smsSender.Send(new Body());

            MessageSenderBase.Send(new Body{Title = "THIS MESSAGE"});
            Console.WriteLine("Customer Updated");
        }
    }

}
