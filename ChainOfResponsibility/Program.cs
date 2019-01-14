using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            CoinsSlot twenty = new TwentyCents();
            CoinsSlot fifty = new FiftyCents();
            CoinsSlot pass = new PassThrough();

          
            fifty.setNextChain(twenty);
            twenty.setNextChain(pass);
            pass.setNextChain(null);

            CoinsSlot main = fifty;

            main.Calculate(1);
            main.Calculate(5);
            main.Calculate(0.2);
            main.Calculate(0.01);
            main.Calculate(0.5);
          
            Console.ReadKey();

           
        }
        public abstract class CoinsSlot
        {
            protected double sum = 0;
            protected CoinsSlot next;
          
            public abstract void Calculate(double value);

            public abstract void setNextChain(CoinsSlot next);
        }

        public class TwentyCents : CoinsSlot
        {
            private double _value = 0.2;
            public override void setNextChain(CoinsSlot next)
            {
                this.next = next;
            }

            public override void Calculate(double value)
            {
                if (_value == value)
                {
                    this.sum += value;
                    Console.WriteLine("adding 20");
                    next.Calculate(value);
                }
                else
                {
                    Console.WriteLine("passing to ");
                    next.Calculate(value);
                }
            }
        }
        public class FiftyCents : CoinsSlot
        {

            private double _value = 0.5;
            public override void setNextChain(CoinsSlot next)
            {
                this.next = next;
            }

            public override void Calculate(double value)
            {
                if (_value == value)
                {
                    this.sum += value;
                    Console.WriteLine("adding 50");
                    next.Calculate(value);
                }
                else
                {
                    Console.WriteLine("passing to");
                    next.Calculate(value);
                }
            }
        }
        public class PassThrough : CoinsSlot
        {


           
            public override void setNextChain(CoinsSlot next)
            {
                this.next = next;
            }

            public override void Calculate(double value)
            {
                    Console.WriteLine("invalid");
              
            }
        }
    }
}
