using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Text.Json;

var options = new JsonSerializerOptions { IncludeFields = true };
string jsonString = JsonSerializer.Serialize(data, options);
Console.WriteLine(jsonString);

File.WriteAllText(@"C:\Users\k.patel61\Desktop\Data_Managment\data-files\shopping.txt", jsonString);

string jsonStringFromFile = File.ReadAllText(@"F:\__CS\C#\file-io-json-demo\data2.txt");
Console.WriteLine(jsonStringFromFile);

List<Point>? data2 = JsonSerializer.Deserialize<List<Point>>(jsonStringFromFile, options);
Console.WriteLine(data2);
if (data2 != null) {
    foreach (var point in data2) {
        Console.WriteLine(point);
    }
}


class Point {
    public string x;
    public string y;

    public Point(string x, string y) {
        this.x = x;
        this.y = y;
    }

    public override string ToString() {
        return $"({this.x},{this.y})";
    }
}

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
                Console.WriteLine("Here are all the grocery items availble in store, there prices, and item codes:");
                for (int i = 0; i < items.Length; i++){
                    Console.Write(items[i]);
                }
            } 
            else if (user_choice == 2){
                Console.Write(@"Please enter the product area code of the types of products you are looking for:
                Baked goods: 234
                Dairy: 998
                Fruits/Vegetables: 222
                Seasoning: 345
                Condiments: 565
                Hyigene: 223");
                string category = Console.ReadLine();
                Console.Write(category);
                for (int i = 0; i < items.Length; i++){
                    if (items[i].Contains(category) == true){
                        Console.WriteLine(items[i]);
                    }
                }
            }
            else if (user_choice == 3){ 
                Console.Write(@"Please enter the name or product number, for the product you would like to add to your shopping cart: ");
                string want = Console.ReadLine();
                Console.Write(want);
                for (int i = 0; i < items.Length; i++){
                    if (items[i].Contains(want) == true){
                        ;
                    }
                }
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


