using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {

            ShippingMethod s = new CourierDelivery();

            Visitor v = new LPExpress();
            s.AddTarriff(v);

            Console.ReadKey();

        }
    }
    public interface ShippingMethod
    {
        void AddTarriff(Visitor v);
     
    }
    public class ParcelTerminal : ShippingMethod
    {
        public void AddTarriff(Visitor v)
        {
            v.Visit(this);
        }
        public void Pay()
        {
            Console.WriteLine("Mokama");
        }
    }
    public class CourierDelivery : ShippingMethod
    {
        public void AddTarriff(Visitor v)
        {
            v.Visit(this);
        }
        public void Test()
        {
            Console.WriteLine("testuojama");
        }
    }

    public interface Visitor
    {
        void Visit(CourierDelivery c);
        void Visit(ParcelTerminal p);
    }

    public class LPExpress : Visitor
    {
        public void Visit(CourierDelivery c)
        {
            c.Test();
        }

        public void Visit(ParcelTerminal p)
        {
            p.Pay();
        }
    }
}
