using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new TvOff());
            context.Request();
            Console.ReadKey();

           
        }
    }
    public interface State
    {
        void Handle();
    }
    public class TvOn : State
    {
        public void Handle()
        {
            Console.WriteLine("Tv on");
        }
    }
    public class TvOff : State
    {
        public void Handle()
        {
            Console.WriteLine("Tv off");
        }
    }
    public class Context
    {
        State state;

        public Context(State state)
        {
            this.state = state;
        }

        public void SetState(State state)
        {
            this.state = state;
        }
        public void Request()
        {
            state.Handle();
        }
    }
}
