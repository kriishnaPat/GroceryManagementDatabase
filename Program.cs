using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Data_Managment
{
    class Program
    {
        public static void Main(string[] args)
        {
        String groceryText = File.ReadAllText(@"C:\Users\k.patel61\Desktop\Data_Managment\data-files\grocery.txt");
        String[] items = Regex.Split(groceryText, @"/");
  
            while (true){
                //usercheck();
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
                Console.WriteLine("Here are all the grocery items availble in store, there prices and item codes:");
                for (int i = 0; i < items.Length; i++){
                    Console.Write(items[i]);
                }
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
        }
    }
}


