using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture8_Hometask
{
    abstract class Elements
    {
        public string Name { get; set; }

        public void AboutMe()
        {
            Console.WriteLine("Im {0}", Name);            
        }
    }

    interface IFlyingObject
    {
        void Fly();
    }

    interface ISwimmingObject
    {
        void Swim();
    }

    interface IRunningObject
    {
        void Run();
    }

    interface IEnginessObject
    {
        void Engine();
    }

    class Airplane : Elements, IFlyingObject, IEnginessObject
    {
        public string Model { get; set; }

        public Airplane(string model, string name)
        {
            this.Model = model;
            this.Name = name;
        }

        public void Fly()
        {
            AboutMe();
            Console.WriteLine("I can fly from Airplane class with IFly");
        }

        public void Engine()
        {
            AboutMe();
            Console.WriteLine("I have engine from Airplane class with IEngine");
        }
    }

    class Eagle : Elements, IFlyingObject
    {
        public void Fly()
        {
            AboutMe();
            Console.WriteLine("I can fly from Eagle class with IFly");
        }
    }

    class Duck : Elements, IFlyingObject, ISwimmingObject
    {
        public void Fly()
        {
            AboutMe();
            Console.WriteLine("I can fly from Duck class with IFly");
        }

        public void Swim()
        {
            AboutMe();
            Console.WriteLine("I can swim from Duck class with ISwim");
        }
    }

    class Cheeken : Elements, IRunningObject
    {
        public void Run()
        {
            AboutMe();
            Console.WriteLine("I can run from Duck class with IRun");
        }
    }

    class EngineBoard : Elements, ISwimmingObject, IEnginessObject
    {
        public void Swim()
        {
            AboutMe();
            Console.WriteLine("I can swim from EngineBoard class with ISwim");
        }

        public void Engine()
        {
            AboutMe();
            Console.WriteLine("I have engine from EngineBoard class with IEngine");
        }
    }

    class Rabbit : Elements, IRunningObject
    {
        public void Run()
        {
            AboutMe();
            Console.WriteLine("I can run from Rabbit class with IRun");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Airplane a = new Airplane("777", "Boing");
            a.Engine();
            a.Fly();

            Eagle b = new Eagle();
            b.Name = "Hawk";
            b.Fly();

            Duck c = new Duck();
            c.Name = "Ducky";
            c.Fly();
            c.Swim();

            Cheeken d = new Cheeken();
            d.Name = "Cheek";
            d.Run();

            EngineBoard e = new EngineBoard();
            e.Name = "Board";
            e.Engine();
            e.Swim();

            Rabbit f = new Rabbit();
            f.Name = "Rab";
            f.Run();

            IFlyingObject[] flying = new IFlyingObject[] { a, b, c };

            foreach (var item in flying)            
                item.Fly();
            
            ISwimmingObject[] swiming = new ISwimmingObject[] { c, e };

            foreach (var item in swiming)            
                item.Swim();            
            
            Console.ReadKey();
        }
    }
}
