using System;


namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Еда.
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; } 
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydraters { get; }
        /// <summary>
        /// Калории за 100 гр продукта.
        /// </summary>
        public double Callories { get; }

        

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        

        public Food(string name, double callories, double proteins, double fats, double carbohydraters)
        {
            //TODO: Проверка
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydraters = carbohydraters / 100.0;     
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
