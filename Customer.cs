using System;
using System.Collections.Generic;
namespace CSharpExamBhriguMahajan
{
    public delegate bool SelectDish(Dish dish);

    public class Customer
    {
        string _name;
        public SelectDish preferences;
        public string Name
        {
            set
            {
                if (value == null || value.ToString() == "")
                    _name = "Bhrigu Mahajan";
                else
                    _name = value;
            }
            get { return _name; }
        }



        public Customer()
        {
            Name = "";
        }

        public Customer(string name)
        {
            Name = name;
        }

        public Customer(string name, SelectDish pref)
        {
            Name = name;
            preferences = pref;
        }
    }
}