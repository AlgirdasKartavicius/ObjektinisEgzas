using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Component c = new Army();
            c.Add(new Army());
            c.Add(new Leaf());
           
            c.GetChild()[0].Add(new Army());
            c.GetChild().Add(new Group());
         /*   c.Add(new Army());
            
            c.Add(new Group());*/
            foreach (var item in c.GetChild())
            {
                item.Operation();
                
            }

            Console.ReadKey();

            
        }
        public abstract class Component
        {
            public virtual void Add(Component c)
            {

            }
            public virtual void Remove(Component c)
            {

            }
            public virtual List<Component> GetChild()
            {
                return null;
            }
            public abstract bool IsComposite();
             public abstract void Operation();
        }
        public class Leaf : Component
        {
            public override bool IsComposite()
            {
                return false;
            }

            public override void Operation()
            {
                Console.WriteLine("Leaf operation");
            }
        }
        public abstract  class Composite : Component
        {
            List<Component> children = new List<Component>();

            public override void Add(Component c)
            {
                children.Add(c);
            }
            public override void Remove(Component c)
            {
                children.Remove(c);
            }
            public override List<Component> GetChild()
            {
                return children;
            }
            public override bool IsComposite()
            {
                return true;
            }

            public override void Operation()
            {
                Console.WriteLine("Composite operation");
            }
        }
        public class Army : Composite
        {
            public Army()
            {
                
            }
            public override void Operation()
            {
                Console.WriteLine("Army operation");
                foreach (var item in this.GetChild())
                {
                    item.Operation();
                }
            }
        }

        public class Group : Composite
        {
            public Group()
            {

            }
            public override void Operation()
            {
                Console.WriteLine("Group operation");
                foreach (var item in this.GetChild())
                {
                    item.Operation();
                }
            }
        }
    }
}
