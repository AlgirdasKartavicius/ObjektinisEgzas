using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {

            CareTaker careTaker = new CareTaker();
            Originator originator = new Originator("pirma");

            Memento state1 = originator.CreateMenento();
            careTaker.Add(state1);
            originator.PrintState();

            originator.SetState("antra");
            Memento state2 = originator.CreateMenento();
            careTaker.Add(state2);
            originator.PrintState();

            Memento restoreMemento = careTaker.Get(0);

            originator.SetMemento(restoreMemento);

            originator.PrintState();

            Console.ReadKey();

        }
    }
    public class Originator
    {
        string State;
        public Originator(string state)
        {
            State = state;
        }

        public void SetState(string newState)
        {
            State = newState;
        }
        public Memento CreateMenento()
        {
            return new Memento(State);
        }
        public void SetMemento(Memento previousState)
        {
            State = previousState.GetState();
        }
        public void PrintState()
        {
            Console.WriteLine(State);
        }
        
    }
    public class Memento
    {
        string _state;

        public Memento(string state)
        {
            _state = state;
        }
        public string GetState()
        {
            return _state;
        }
        public void SetState(string s)
        {
            _state = s;
        }
    }
    public class CareTaker
    {
        List<Memento> states;

        public CareTaker()
        {
           states = new List<Memento>();
        }

        public void Add(Memento m)
        {
            states.Add(m);
        }

        public Memento Get(int index)
        {
            Memento restoreState = states[index];
            states.Remove(restoreState);
            return restoreState;
        }

    }
}
