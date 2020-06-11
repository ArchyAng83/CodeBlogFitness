﻿using System;


namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Еда.
    /// </summary>
    [Serializable]
    public class Food
    {
        public int Id { get; set; }

        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; set; } 
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калории за 100 гр продукта.
        /// </summary>
        public double Callories { get; set; }

        

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        

        public Food(string name, double callories, double proteins, double fats, double carbohydrates)
        {
            //TODO: Проверка
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;     
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
