using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace CSharpExamBhriguMahajan
{
    class Program
    {
        string myXML = "C:\\Users\\MAHAJA\\source\\repos\\CSharpExamBhriguMahajan\\CSharpExamBhriguMahajan\\myMenu.xml";
        public static void Main(string[] args)
        {
            Program prog= new Program();
            prog.work();
        }

        public void work()
        {
            IRestaurant fastnFat = new Restaurant(new fillMenu(FastFood));
            fastnFat.Open();

            Customer Jack = new Customer("Jack", new SelectDish(Rich));
            Jack.preferences += new SelectDish(Fatty);
            fastnFat.Welcome(Jack);

            Customer Tao = new Customer("Tao", new SelectDish(Vegan));
            Tao.preferences += new SelectDish(x => x.vegan == true);
            fastnFat.Welcome(Tao);

            Console.ReadLine();

        }

        public List<Dish> FastFood()
        {
            List<Dish> menu = new List<Dish>();
            if (myXML == "")
            {
                menu.Add(new Dish("Burger", Course.MAIN, 380, 15, false));
                menu.Add(new Dish("Salad", Course.STARTER, 80, 8, true));
                menu.Add(new Dish("ChocMousse", Course.DESSERT, 120, 5, false));
                menu.Add(new Dish("Apple", Course.DESSERT, 12, 2, true));
                menu.Add(new Dish("Okonomiaki", Course.MAIN, 300, 16, true));
            }
            else
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Dish>));
                using (StreamReader sr = new StreamReader(myXML))
                {
                    menu = xs.Deserialize(sr) as List<Dish>;
                }
            }
            return menu;
        }

        public bool Rich(Dish dish)
        {
            if (dish.calories >= 50)
                return true;
            return false;
        }

        public bool Fatty(Dish dish)
        {
            if (dish.calories >= 80)
                return true;
            return false;
        }

        public bool Vegan(Dish dish)
        {
            if (dish.vegan)
                return true;
            return false;
        }

    }
}
