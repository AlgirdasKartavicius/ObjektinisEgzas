using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Aggregate aggregate = new ConcreteAggregate();
            aggregate.Add(new Song("aaa"));
            aggregate.Add(new Song("bbb"));
            
            IIterator iterator = aggregate.CretateIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next().Name);
            }

            Console.ReadKey();

        }

    }
    public interface Aggregate{
         IIterator CretateIterator();
         void Add(Song a);
         void Remove(Song a);
    }
    public interface IIterator
    {
         Song First();
        Song Next();
        bool HasNext();
        Song CurrentItem();

    }
    public class ConcreteIIterator : IIterator
    {
        private ConcreteAggregate ConcreteAggregate;
        private int index = 0;
        public ConcreteIIterator(ConcreteAggregate a)
        {
            ConcreteAggregate = a;
        }
        public Song CurrentItem()
        {

            return ConcreteAggregate.GetSong(index);
           
        }

        public Song First()
        {
            return ConcreteAggregate.GetSong(0);
        }

        public bool HasNext()
        {
            return index < ConcreteAggregate.count ? true : false;
        }

        public Song Next()
        {
            return ConcreteAggregate.GetSong(index++);
        }
    }
    public class ConcreteAggregate : Aggregate
    {
        private List<Song> songs = new List<Song>();
        public int count = 0;
        public void Add(Song a)
        {
            count++;
            songs.Add(a);
        }
        public void Remove(Song a)
        {
            count--;
            songs.Remove(a);
        }
        public Song GetSong(int index)
        {
            return songs[index];
        }
        public IIterator CretateIterator()
        {
           return new ConcreteIIterator(this);
        }
    }
    public class Song
    {
        public Song(string n)
        {
            Name = n;
        }
        public string Name { get; set; }
    }
}
