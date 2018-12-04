using System;
using System.Collections.Generic;
namespace CSharpExamBhriguMahajan
{
    public delegate List<Dish> fillMenu();

    public interface IRestaurant
    {
        void Open();
        void Welcome(Customer cus);
    }
}