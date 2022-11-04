
using System;
namespace As4
{
    // Class name:      Animal
    // Description:     parent class for subclass Snake and Cat.
    // Properties:
    //      ID/id
    //      Age/age
    //      Name/name
    //      Pos         Position object with properties X, Y, Z as coordinates
    public class Animal: IComparable
    {
        // private properties
        
        private string name;
        private int id;
        private double age;


        // setter and getters
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        public double Age
        {
            set { age = value; }
            get { return age; }
        }
        public int CompareTo(object obj)
        {
            Animal b = obj as Animal;
            if (obj == null) return -2;
            if (id < b.id)
                return -1;
            if (id > b.id)
                return 1;
            else return 0;
        }
        public override string ToString()
        {
            string property = ("ID:" + ID);
            return property;
        }
    }
}
