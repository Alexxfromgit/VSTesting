using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace Lecture13_Hometask
{
    [Serializable]
    class AlenkasWish : EventArgs
    {
        public string Message { get; set; }
        public AlenkasWish(string s)
        {
            Message = s;
        }
    }

    [Serializable]
    delegate void Wish(object sender, AlenkasWish e);

    [Serializable]
    class Hero
    {
        public string Name { get; set; }

        public Hero(string name)
        {
            this.Name = name;
        }

        public event Wish StartHide;
        public void MakeHide(string s)
        {
            StartHide?.Invoke(this, new AlenkasWish(s));
        }

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    class MagicObject
    {
        public string Name { get; set; }

        public MagicObject(string name)
        {
            this.Name = name;
        }

        public void CatchHide(object c, AlenkasWish e)
        {
            Console.WriteLine("Хорошо, я спрячу вас! {0} {1}", c.ToString(), e.Message);
        }
    }

    [Serializable]
    class WrongAnswerException : Exception
    {
        public override string Message => "Неправильный выбор";
    }

    [Serializable]
    class Story
    {
        List<MagicObject> MagicList = new List<MagicObject>();
        List<Hero> HeroList = new List<Hero>();

        int countWrongAnswers = 0;
        int countNo = 0;

        public void CreateMagicList()
        {
            MagicList.Add(new MagicObject("Ежик"));
            MagicList.Add(new MagicObject("Яблонь"));
            MagicList.Add(new MagicObject("Молочная река"));
            MagicList.Add(new MagicObject("Печь"));
        }

        public void CreateHeroes()
        {
            HeroList.Add(new Hero("Баба Яга"));
            HeroList.Add(new Hero("Гуси-Лебеди"));
            HeroList.Add(new Hero("Аленка"));
            HeroList.Add(new Hero("Иванушка"));
        }

        public void BeginStory()
        {
            Console.WriteLine("");
            Console.WriteLine("Игра Баба-Яга. Гуси-Лебеди");
            Console.WriteLine("");
            Console.WriteLine("{0} и {1} убежали от {2}.", HeroList[2].Name, HeroList[3].Name, HeroList[0].Name);
            Console.WriteLine("{0} погнались за детьми.", HeroList[1].Name);
        }

        public void RunFromGusi()
        {
            Console.WriteLine("Начали бежать дети через магический лес..");
            char question = 'a';
            int answer;

                for (int i = 0; i < MagicList.Capacity; i++)
                {
                    if (countNo < 3)
                    {
                        Console.WriteLine("Встретили детки {0}", MagicList[i].Name);
                        Console.WriteLine("{0} спрячь нас пожалуйста!", MagicList[i].Name);
                        Console.WriteLine("Хорошо, но если правильно ответишь на мой вопрос");
                    }

                    if (countWrongAnswers < 3 & countNo < 3)
                    {
                        while ((question != 'y') && (question != 'n') || (question == ' '))
                        {
                            try
                            {
                                switch (countWrongAnswers)
                                {
                                    case 0:
                                    case 1:
                                        Console.WriteLine("Еще есть возможность ответить на {0} вопроса", 3 - countWrongAnswers - countNo);
                                        break;
                                    case 2:
                                        Console.WriteLine("Еще есть возможность ответить на {0} вопрос", 3 - countWrongAnswers - countNo);
                                        break;
                                }

                                Console.Write("Ответить на вопрос?[y/n]");
                                question = Convert.ToChar(Console.ReadLine());

                                if ((question != 'y') && (question != 'n') || (question == ' '))
                                {
                                    throw new WrongAnswerException();
                                }
                            }
                            catch (WrongAnswerException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        if (question == 'y')
                        {
                            switch (MagicList[i].Name)
                            {
                                case "Ежик":
                                    Console.WriteLine("Сколько 2+2?");
                                    answer = Int32.Parse(Console.ReadLine());
                                    if (answer == 4)
                                    {
                                        Console.WriteLine("Правильно, я вас спрячу!");
                                        Console.WriteLine("{0} полетали, покричали и пролетели мимо", HeroList[1].Name);
                                        i = 5;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Нет, ответ не верный! Я вас не спрячу!");
                                        countWrongAnswers += 1;
                                        question = 'a';
                                        if (countWrongAnswers >= 3)
                                        {
                                            i = 5;
                                            Console.WriteLine("Вы проиграли! Вас догнали {0}", HeroList[1].Name);
                                        }
                                    }
                                    break;
                                case "Яблонь":
                                    Console.WriteLine("Сколько 3+3?");
                                    answer = Int32.Parse(Console.ReadLine());
                                    if (answer == 6)
                                    {
                                        Console.WriteLine("Правильно, я вас спрячу!");
                                        Console.WriteLine("{0} полетали, покричали и пролетели мимо", HeroList[1].Name);
                                        i = 5;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Нет, ответ не верный! Я вас не спрячу!");
                                        countWrongAnswers += 1;
                                        question = 'a';
                                        if (countWrongAnswers >= 3)
                                        {
                                            i = 5;
                                            Console.WriteLine("Вы проиграли! Вас догнали {0}", HeroList[1].Name);
                                        }
                                    }
                                    break;
                                case "Молочная река":
                                    Console.WriteLine("Сколько 4+4?");
                                    answer = Int32.Parse(Console.ReadLine());
                                    if (answer == 8)
                                    {
                                        Console.WriteLine("Правильно, я вас спрячу!");
                                        Console.WriteLine("{0} полетали, покричали и пролетели мимо", HeroList[1].Name);
                                        i = 5;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Нет, ответ не верный! Я вас не спрячу!");
                                        countWrongAnswers += 1;
                                        question = 'a';
                                        if (countWrongAnswers >= 3)
                                        {
                                            i = 5;
                                            Console.WriteLine("Вы проиграли! Вас догнали {0}", HeroList[1].Name);
                                        }
                                    }
                                    break;
                                case "Печь":
                                    Console.WriteLine("Сколько 5+5?");
                                    answer = Int32.Parse(Console.ReadLine());
                                    if (answer == 10)
                                    {
                                        Console.WriteLine("Правильно, я вас спрячу!");
                                        Console.WriteLine("{0} полетали, покричали и пролетели мимо", HeroList[1].Name);
                                        i = 5;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Нет, ответ не верный! Я вас не спрячу!");
                                        countWrongAnswers += 1;
                                        question = 'a';
                                        if (countWrongAnswers >= 3)
                                        {
                                            i = 5;
                                            Console.WriteLine("Вы проиграли! Вас догнали {0}", HeroList[1].Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            countNo += 1;
                            Console.WriteLine("Ну как хотите..");
                            Console.WriteLine("Бежим дальше..");
                            Console.WriteLine("{0} были все ближе и догоняли деток.", HeroList[1].Name);
                            question = 'a';
                            if (countNo >= MagicList.Capacity && countNo >= 3)
                            {
                                Console.WriteLine("Вы проиграли! Вас догнали {0}", HeroList[1].Name);
                                i = 5;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы проиграли! Вас догнали {0}", HeroList[1].Name);
                    }
                }
        }
    }


    class SaveProgress
    {
        public void StartSaveGame(Story obj)
        {
            char question = 'a';
            //Сохранение игры
            while ((question != 'y') && (question != 'n') || (question == ' '))
            {
                try
                {
                    Console.Write("Сохранить игру?[y/n]");
                    question = Convert.ToChar(Console.ReadLine());

                    if ((question != 'y') && (question != 'n') || (question == ' '))
                    {
                        throw new WrongAnswerException();
                    }
                }
                catch (WrongAnswerException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (question == 'y')
            {
                if (File.Exists("savegame.dat"))
                    File.Delete("savegame.dat");

                FileStream filetosave = new FileStream("savegame.dat", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(filetosave, obj);
                filetosave.Close();
                Console.WriteLine("Игра сохранена!");
            }
        }

        public void RunSavedGame(Story obj)
        {
            char question = 'a';
            //Загрузка игры
            while ((question != 'y') && (question != 'n') || (question == ' '))
            {
                try
                {
                    Console.Write("Загрузить игру?[y/n]");
                    question = Convert.ToChar(Console.ReadLine());

                    if ((question != 'y') && (question != 'n') || (question == ' '))
                    {
                        throw new WrongAnswerException();
                    }
                }
                catch (WrongAnswerException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (question == 'y')
            {
                FileStream filetoload = new FileStream("savegame.dat", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                obj = (Story)formatter.Deserialize(filetoload);
                Console.WriteLine("Игра загружена");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Story story = new Story();
            SaveProgress savep = new SaveProgress();

            story.CreateHeroes();
            story.CreateMagicList();

            story.BeginStory();

            savep.RunSavedGame(story);
            
            story.RunFromGusi();

            savep.StartSaveGame(story);

            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }
    }
}
