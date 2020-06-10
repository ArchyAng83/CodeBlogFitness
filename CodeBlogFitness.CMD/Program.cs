using System;
using System.Globalization;
using System.Resources;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-en");
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Message_ru-ru", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();
                        
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseContreller = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол : ");
                var gender = Console.ReadLine();

                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");
                

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

           
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exercise = EnterExercise();
                        exerciseContreller.Add(exercise.Activity, exercise.Start, exercise.Finish);
                        foreach (var item in exerciseContreller.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                }

                Console.ReadLine();
            }
        }

        private static (DateTime Start, DateTime Finish, Activity Activity) EnterExercise()
        {
            Console.Write("Введите упражнение : ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии");

            var start = ParseDateTime("начало упражнения");
            var finish = ParseDateTime("окончание упражнения");

            var activity = new Activity(name, energy);

            return (start, finish, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите название продукта : ");
            var food = Console.ReadLine();
                        
            var weight = ParseDouble("вес порции");
            var callories = ParseDouble("калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbohydraters = ParseDouble("углеводы");

            var product = new Food(food, callories, proteins, fats, carbohydraters);

            return (Food : product, Weight : weight);
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный {name}.");
                }
            }
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} : ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}.");
                }
            }

            return birthDate;
        }
    }
}
