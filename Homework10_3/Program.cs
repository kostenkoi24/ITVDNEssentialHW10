using System;

namespace Homework10_3
{

    class Human { };

    class Alien { };

    interface ITypeOfCreature<T>
    {
        public void SaveCreature();
    }



    class MagicBag<T> : ITypeOfCreature<T>
    {
        static string present { get; set; }

        T who;

        public string creature;

        public MagicBag(T who)
        {
            MagicBag<T>.present = "Present for " + who.GetType().Name + " " + DateTime.Now;
            this.who = who;
            
        }

        public string OpenBag()
        {
            return present;
        }

        public void SaveCreature()
        {
            creature = who.GetType().Name;
        }
        

    }

    class Program
    {
        static void Main(string[] args)
        {

            Human human = new Human();
            Alien alien = new Alien();


            
            MagicBag<Human> presentForHuman = new MagicBag<Human>(human);
            Console.WriteLine(presentForHuman.OpenBag());
            presentForHuman.SaveCreature();
            Console.WriteLine(presentForHuman.creature);

            


            MagicBag<Alien> presentForAlien = new MagicBag<Alien>(alien);
            Console.WriteLine(presentForAlien.OpenBag());
            presentForAlien.SaveCreature();
            Console.WriteLine(presentForAlien.creature);


           



            Console.ReadKey();

        }
    }
}
