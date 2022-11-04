using System;
using System.IO;


namespace As4
{
    // Snake
    // Subclass of Animal parent class
    public class Snake : Animal
    {
        private bool venomous;
        private double length;

        public Snake()
        {
            var random = new Random();
            ID = random.Next(1000);

        }

        // formats property as a string
        public override string ToString()
        {
            string property = ("Snake ID:" + ID );
            return property;
        }
    }
}