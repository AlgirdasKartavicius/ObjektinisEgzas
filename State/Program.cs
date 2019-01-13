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
            State state = new TvOff();
            Context context = new Context(state);
            state.GoNext(context);
            
            context.Request();
            Console.ReadKey();

           
        }
    }
    public interface State
    {
        void Handle();
        void GoNext(Context c);
    }
    public class TvOn : State
    {
        public void GoNext(Context c)
        {
            c.SetState(new TvOff());
        }

        public void Handle()
        {
            Console.WriteLine("Tv on");
        }
    }
    public class TvOff : State
    {
        public void GoNext(Context c)
        {
            c.SetState(new TvOn());
        }

        public void Handle()
        {
            Console.WriteLine("Tv off");
        }
    }
    public class Context
    {
        List<State> states = new List<State>();
        State state;

        public Context(State state)
        {
            this.state = state;
        }

        public void SetState(State state)
        {
            states.Add(state);
            this.state = state;
        }
        public void Request()
        {
            state.Handle();
        }
    }
}
