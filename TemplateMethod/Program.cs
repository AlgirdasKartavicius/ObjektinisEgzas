using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            TemplateMethod t = new Bike();
            t.FinalTemplateMethod();
          
            Console.ReadKey();

           
        }
    }
    public abstract class TemplateMethod
    {
        //final per kontrolinį, tipo su java :D
        public void FinalTemplateMethod()
        {
            SetSpeed();
            if (CanSetName())
            {
                SetName();
            }
        }
        public abstract void SetSpeed();
        public abstract void SetName();
        public abstract bool CanSetName();
    }
    public class Bike : TemplateMethod
    {
        public override bool CanSetName()
        {
            return true;
        }

        public override void SetName()
        {
            Console.WriteLine("dviratis");
        }

        public override void SetSpeed()
        {
            Console.WriteLine("greitis 5");
        }
    }
    public class Car : TemplateMethod
    {
        public override bool CanSetName()
        {
            return false;
        }

        public override void SetName()
        {
            Console.WriteLine("masina");
        }

        public override void SetSpeed()
        {
            Console.WriteLine("greitis 10");
        }
    }
}
