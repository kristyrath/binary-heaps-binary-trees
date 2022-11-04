using System;

namespace As4
{
    // Cat
    // Subclass of Animal parent class

    public class Cat : Animal
    {

        public Cat()
        {
            var random = new Random();
            ID = random.Next(1000);

        }
        // setter and getter for property CatBreed
    

        // Formats string to print properties
        public override string ToString()
        {
            string property = ("Cat ID:" + ID );
            return property;
        }

    }
}
