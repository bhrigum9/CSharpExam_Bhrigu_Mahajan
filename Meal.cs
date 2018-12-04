using System;
namespace CSharpExamBhriguMahajan
{
    public struct Meal
    {
        int bill,energy;

        public void Start()
        {
            energy = 0;
            bill = 0;
        }

        public void AddDish(Dish dish)
        {
            energy += dish.calories;
            bill += dish.price;
        }

        public int GetEnergy()
        {
            return energy;
        }
        public int GetBill()
        {
            return bill;
        }
    }
}