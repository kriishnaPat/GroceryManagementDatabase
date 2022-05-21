using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace Data_Managment
{
static class MainList{
            static List<List<List<string>>> userChoice;
            
            static MainList()
            {
                // Allocate the list.
                userChoice = new List<List<List<string>>>();
            }
            
            public static void Record(List<List<string>> value)
            {
                // Record this value in the list.
                userChoice.Add(value);
            }
            public static void Remove(List<List<string>> value){
                userChoice.Remove(value);
            }
    class Program
    {       
        public  static void Main(string[] args)
        {
            //load stuff on file already
            String groceryText = File.ReadAllText(@"data-files/grocery.txt");
            String[] items = Regex.Split(groceryText, @"/");
            
            static void retrieveFile(){
                string jsonStringFromFile = File.ReadAllText(@"data-files/data.txt");
                List<List<List<string>>> data = JsonSerializer.Deserialize<List<List<List<string>>>>(jsonStringFromFile);
                Console.Write(jsonStringFromFile);
                if (jsonStringFromFile == " ")
                {
                    List<List<List<string>>> userChoice = new List<List<List<string>>>();
                    usercheck(userChoice);
                }
                else
                {
                    List<List<List<string>>> userChoice = JsonSerializer.Deserialize<List<List<List<string>>>>(jsonStringFromFile);
                    usercheck(userChoice);
                }
            }
            retrieveFile();
            while (true)
            {
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
                if (user_choice == 1)
                {
                    Console.WriteLine("Here are all the grocery items availble in store, there prices, and item codes:");
                    for (int i = 0; i < items.Length; i++)
                    {
                        Console.Write(items[i]);
                    }
                }
                else if (user_choice == 2)
                {
                    Console.Write(@"Please enter the product area code of the types of products you are looking for:
                Baked goods: 234
                Dairy: 998
                Fruits/Vegetables: 222
                Seasoning: 345
                Condiments: 565
                Hyigene: 223");
                    string category = Console.ReadLine(); //fix if last 3 digits are 
                    Console.Write(category);
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].Contains(category) == true)
                        {
                            Console.WriteLine(items[i]);
                        }
                    }
                }
                else if (user_choice == 3)
                {
                    List<string> shoppingCart = new List<string>();
                    Console.Write(@"Please enter the name or product number, for the product you would like to add to your shopping cart: ");
                    string want = Console.ReadLine();
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].Contains(want) == true)
                        {
                            Console.WriteLine(items[i]);
                            Console.Write($"{items[i]}Is this what you are looking for, press 1 for yes or 2 for no:");
                            string yn = Console.ReadLine();
                            if (yn == "1")
                            {
                                string itemWanted = items[i];
                                shoppingCart.Add(itemWanted);
                            }
                        }
                    }
                    userChoice[0].Add(shoppingCart);
                }
                else if (user_choice == 4)
                {
                    Console.Write(@"Please enter the name or product number, for the product you would like to remove from your shopping cart: ");
                    string remove = Console.ReadLine();
                    Console.Write(remove);
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].Contains(remove) == true)
                        {
                        }
                    }
                }
                else if (user_choice == 5)
                {
                }
                else if (user_choice == 6)
                {
                    break;
                }
                else
                {
                    Console.Write("That was not a valid choice!");
                }
            }
            static void usercheck(List<List<List<string>>> userChoice)
            {
                bool userExists = false;
                while (!userExists)
                {
                    List<string> login = new List<string>();
                    List<string> cart = new List<string>();
                    List<List<string>> profile = new List<List<string>>();
                    Console.WriteLine("Enter 1 if you are a new user, enter 2 if you are an exisiting user: ");
                    string user = Console.ReadLine();
                    if (user == "1")
                    {
                        Console.WriteLine("Enter a username of your choosing: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter a Password of your choosing: ");
                        string password = Console.ReadLine();
                        for (int i = 0; i < userChoice.ToArray().Length; i++)
                        {
                            if (userChoice[i][0][0] == username)
                            {
                                Console.WriteLine(@$"Please try again this username is taken.");
                            }
                        }
                        login.Add(username);
                        login.Add(password);
                        profile.Add(login);
                        profile.Add(cart);
                        userChoice.Add(profile);
                        string jsonString = JsonSerializer.Serialize(userChoice);
                        File.WriteAllText(@"data-files/data.txt", jsonString);
                        Console.WriteLine("Your account has been made please sign in now!");
                    }
                    else if (user == "2")
                    {
                        Console.WriteLine("Enter Username: ");
                        string usernameN = Console.ReadLine();
                        Console.WriteLine("Enter Password: ");
                        string passwordN = Console.ReadLine();
                        int total = userChoice.ToArray().Length;
                        for (int i = 0; i < userChoice.ToArray().Length; i++)
                        {
                            if (userChoice[i][0][0] == usernameN && userChoice[i][0][1] == passwordN)
                            {
                                int index = i;
                                Console.WriteLine(@$"Welcome {usernameN} to the grocery store!");
                                userExists = true;
                                break;
                            }
                        }
                        if (!userExists)
                        {
                            Console.WriteLine("Your username or password is incorrect");
                        }
                    }
            }
        }
            
        //     static void editCart(List<string> items)
        //     {
        //         List<string> shoppingCart = new List<string>();
        //         Console.Write(@"Please enter the name or product number, for the product you would like to add to your shopping cart: ");
        //         string want = Console.ReadLine();
        //         Console.Write(want);
        //         for (int i = 0; i < 5; i++)
        //         {
        //             if (items[i].Contains(want) == true)
        //             {
        //                 Console.Write($"{items[i]}Is this what you are looking for, press 1 for yes or 2 for no:");
        //                 string yn = Console.ReadLine();
        //                 if (yn == "1")
        //                 {
        //                     string want = items[i];
        //                     shoppingCart.Add(want);
        //                     userChoice[i].Add(shoppingCart);
        //                 }
        //             }
        //         }
        //     }
        // }
    }
}
}
}
