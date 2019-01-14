using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new MediatorImpl();
            User u1 = new Student(mediator, "Petras");
            User u2 = new Student(mediator, "Jonas");
            User u3 = new Student(mediator, "Sigis");

            mediator.AddUser(u1);
            mediator.AddUser(u2);
            mediator.AddUser(u3);
            u1.SendMessage("Sveiki");
            u3.SendMessage("test");


            Console.ReadKey();
          
        }
    }
    public interface Mediator
    {
        void AddUser(User a);
        void BroadcastMessage(User user, string message);
    }
    public class MediatorImpl : Mediator
    {
        List<User> users = new List<User>();
        public void AddUser(User a)
        {
            users.Add(a);
        }

        public void BroadcastMessage(User user, string message)
        {
            foreach (var item in users)
            {
                if(item != user)
                {
                    item.ReceiveMessage(message);
                }
            }
        }
    }
    public abstract class User
    {
        protected Mediator m;
        protected string name;
        public User(Mediator mediator, string newName)
        {
            m = mediator;
            name = newName;

        }
        public abstract void SendMessage(string msg);
        public abstract void ReceiveMessage(string mesg);
    }
    public class Student : User
    {
        public Student(Mediator mediator, string newName) : base (mediator, newName)
        {
            m = mediator;
            name = newName;
        }
        public override void ReceiveMessage(string mesg)
        {
            Console.WriteLine(name + " received " + mesg);
        }

        public override void SendMessage(string msg)
        {
            Console.WriteLine(name + " sent " + msg);
            m.BroadcastMessage(this, msg);
        }
    }
}
