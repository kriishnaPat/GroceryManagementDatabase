using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace Data_Managment
{

    class Program
    {
        public static void Main(string[] args)
        {
        //load stuff on file already
        String groceryText = File.ReadAllText(@"data-files/grocery.txt");
        String[] items = Regex.Split(groceryText, @"/");
        
        string jsonStringFromFile = File.ReadAllText(@"data-files/data.txt");
        List<List<string>> data = JsonSerializer.Deserialize<List<List<string>>>(jsonStringFromFile);
        Console.Write(jsonStringFromFile);
        if (jsonStringFromFile == " "){
            List<List<string>> userChoice = new List<List<string>>();
            usercheck(userChoice);
        }else{
            List<List<string>> userChoice = JsonSerializer.Deserialize<List<List<string>>>(jsonStringFromFile);
            usercheck(userChoice);
        }

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
                    }
                }
            }
            else if (user_choice == 4){
                Console.Write(@"Please enter the name or product number, for the product you would like to remove from your shopping cart: ");
                string remove = Console.ReadLine();
                Console.Write(remove);
                for (int i = 0; i < items.Length; i++){
                    if (items[i].Contains(remove) == true){

                    }
                }
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
            static void usercheck(List<List<string>> userChoice){
            List<string> userPass = new List<string>();
            Console.WriteLine("Enter 1 if you are a new user, enter 2 if you are an exisiting user: ");
            string user = Console.ReadLine();
            if (user == "1"){
            Console.WriteLine("Enter a username of your choosing : ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter a Password of your choosing: ");
            string password = Console.ReadLine();
            userPass.Add(username);
            userPass.Add(password);
            userChoice.Add(userPass);
            string jsonString = JsonSerializer.Serialize(userChoice);
            File.WriteAllText(@"data-files\data.txt", jsonString);
            }
            else if (user == "2"){
            Console.WriteLine("Enter Username: ");
            string usernameN = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string passwordN = Console.ReadLine();
            int total = userChoice.ToArray().Length;
            Console.Write(total);
            Display(userChoice);
            for (int i = 0; i < userChoice.ToArray().Length; i++){
                if(userChoice[i][0] == usernameN && userChoice[i][1] == passwordN){
                    Console.WriteLine(@$"Welcome {usernameN} to the grocery store!");
                }
            }
        }
        }
        }

    static void Display(List<List<int>> list)
    {
        // Part 2: loop over and display everything in the List.
        Console.WriteLine("Elements:");
        foreach (var sublist in list)
        {
            foreach (var value in sublist)
            {
                Console.Write(value);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}
}
