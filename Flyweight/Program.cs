using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            FlyweightFactory flyweightFactory = new FlyweightFactory();
            flyweightFactory.GetFlyweight("lektuvas").Draw();
            for (int i = 0; i < 100; i++)
            {
                flyweightFactory.GetFlyweight("lektuvas").Draw();
            }
            flyweightFactory.GetFlyweight("laivas").Draw();
            Console.ReadKey();

        }
    }
    public interface IFlyweight
    {
        void Draw();
    }

    public class FlyweightFactory
    {
        Dictionary<string, IFlyweight> keyValuePairs = new Dictionary<string, IFlyweight>();

        public IFlyweight GetFlyweight(string key)
        {
            IFlyweight flyweight = null ;

            if(keyValuePairs.ContainsKey(key))
            {
                flyweight = keyValuePairs[key];
            }
            else if(key == "lektuvas")
            {
                flyweight = new Plane();

                keyValuePairs.Add(key, flyweight);

            }
            else if(key == "laivas")
            {
                flyweight = new Ship();

                keyValuePairs.Add(key, flyweight);
            }
            return flyweight;
         
        }
    }
    public class Plane : IFlyweight
    {
        public Plane()
        {
        }

        public void Draw()
        {
            Console.WriteLine("Piesiamas lektuvas");
        }
    }
    public class Ship : IFlyweight
    {
        public Ship()
        {
        }

        public void Draw()
        {
            Console.WriteLine("piesiamas laivas");
        }
    }
}
