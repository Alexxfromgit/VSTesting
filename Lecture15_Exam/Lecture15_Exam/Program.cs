using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Lecture15_Exam
{
    class FootballPlayer
    {
        public string LastName { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                    age = value;
                else age = 0;
            }
        }

        private int skill;
        public int Skill
        {
            get { return skill; }
            set
            {
                Random rnd = new Random();
                skill = rnd.Next(0, 101);
            }
        }        

        public FootballPlayer(string LastName, int Age)
        {
            this.LastName = LastName;
            this.Age = Age;
            this.Skill = skill;
        }        
    }

    class Comand
    {
        public string Name { get; set; }
        public List<FootballPlayer> PlayersList; //{ get; set; }
        public double ComandSkill { get; set; }
        Trener tren = new Trener("Treneer");

        public Comand(string Name)
        {
            this.Name = Name;
            this.PlayersList = new List<FootballPlayer>();
        }

        public void AddPlayer(string LastName, int Age)
        {
            FootballPlayer playt = new FootballPlayer(LastName, Age);
            Trener tren = new Trener("trene");

            PlayersList.Add(playt);
            ComandSkill += playt.Skill * tren.Lucky;
        }

        public void ListOfPlayers()
        {
            var query = from pl in PlayersList
                        let lastname = pl.LastName
                        orderby lastname
                        select lastname;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Game
    {
        Comand firstComand = new Comand("Manchester");
        Comand secondComand = new Comand("Inter");
        Judge sud = new Judge("sudia");

        public void GameResult()
        {
            firstComand.AddPlayer("Alex", 22);
            firstComand.AddPlayer("Boris", 30);

            secondComand.AddPlayer("Alla", 24);
            secondComand.AddPlayer("Semen", 33);
            secondComand.AddPlayer("Vasa", 25);

            if ((Math.Max(firstComand.ComandSkill, secondComand.ComandSkill) * 0.9) < Math.Min(firstComand.ComandSkill, secondComand.ComandSkill))
            {
                Console.WriteLine("This is draw match");
            }
            else
            {
                Console.WriteLine("The winner is {0}", firstComand.Name);
            }

            firstComand.ListOfPlayers();
            secondComand.ListOfPlayers();
        }
    }

    class Trener
    {
        public string LastName { get; set; }
        public double GetRandomDouble(double min, double max)
        {
            Random ran = new Random();
            return ran.NextDouble() * (max - min) + min;
        }
        private double lucky;
        public double Lucky { get { return lucky; }
            set
            {
                lucky = GetRandomDouble(0.1, 1.5);
            }
        }

        public Trener(string LastName)
        {
            this.LastName = LastName;
            this.lucky = Lucky;
        }
    }
    class Judge
    {
        public string LastName { get; set; }
        private int coef;
        public int Coef { get { return coef; }
            set
            {
                Random rnd = new Random();
                coef = rnd.Next(0, 2);
            }
        }
        public Judge(string LastName)
        {
            this.LastName = LastName;
            this.coef = Coef;
        }
    }
    class MyException : Exception
    {
        
    }
    class Weather
    {

    }

    class Program
    {



        static void Main(string[] args)
        {




            Game game = new Game();
            game.GameResult();







            Console.ReadKey();
        }
    }
}
