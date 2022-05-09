using System;
using System.Text.RegularExpressions;

namespace Data_Managment
{
    class Program
    {
        public static void Main(string[] args)
        {
            String products = System.IO.File.ReadAllText(@"data-files/grocery.txt");
            String[] productsArr = Regex.Split(products, @",");
            printStringArray(productsArr, 0, 3);
            while (true){
                //diplays menu options
                Console.WriteLine(@"
1.Display all of the products
2.Display certain products
3.Select products to add to shopping cart.
4.Remove products from shopping cart.
5.Display shopping cart.
6.Logout
");
            Console.Write("Enter the number for your choice: ");
            int user_choice = Convert.ToInt32(Console.ReadLine());
            if (user_choice == 1){
                
            } 
            else if (user_choice == 2){
            }
            else if (user_choice == 3){ 
            }
            else if (user_choice == 4){
            }
            else if (user_choice == 5){
            }
            else if (user_choice == 6){
                break;
            }
            else {
                Console.Write("That was not a valid choice!");
            }
        }
        static void printStringArray(String[] array, int start, int stop) {
            // Print out array elements at index values from start to stop 
            for (int i = start; i < stop; i++) {
            Console.WriteLine(array[i]);
            }
    }
  }
}
}

