using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace Data_Managment
{
    class Program
    {
        //assigning global variable to the users profile index of the list so it can be accessed throughout the entire program
        public static int index;
        public static void Main(string[] args)
        {
            //load in grocery products from file already
            String groceryText = File.ReadAllText(@"data-files/grocery.txt");
            String[] items = Regex.Split(groceryText, @"/");

            static void retrieveFile()
            {
                //loads login data already saved to file
                string jsonStringFromFile = File.ReadAllText(@"data-files/data.txt");
                //deserializes existing data
                List<List<List<string>>> data = JsonSerializer.Deserialize<List<List<List<string>>>>(jsonStringFromFile);
                if (jsonStringFromFile == " ")
                {
                    //if file is empty makes new profiles list
                    List<List<List<string>>> profiles = new List<List<List<string>>>();
                    //calls on login function
                    usercheck(profiles);
                }
                else
                {
                    //if file contains data turns it back into usable data
                    List<List<List<string>>> profiles = JsonSerializer.Deserialize<List<List<List<string>>>>(jsonStringFromFile);
                    //uses data that was deserialized and calls on login function
                    usercheck(profiles);
                }
            }
            //Calls on above function to prompt user to login!
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
                //prompts user to enter menu choice
                Console.Write("Enter the number for your choice: ");
                int user_choice = Convert.ToInt32(Console.ReadLine());
                //allows user to see all items availble in store
                if (user_choice == 1)
                {
                    Console.WriteLine("Here are all the grocery items availble in store, there prices, and item codes:");
                    for (int i = 0; i < items.Length; i++)
                    {
                        Console.Write(items[i]);
                    }
                }
                //allows user to sort grocery store items based on category
                else if (user_choice == 2)
                {
                    Console.WriteLine(@"Please enter the product area code of the types of products you are looking for:
                Baked goods: 234
                Dairy: 998
                Fruits/Vegetables: 222
                Seasoning: 345
                Condiments: 565
                Hyigene: 223");
                    string category = Console.ReadLine();
                    Console.WriteLine(category);
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
                    //calls on add to cart function to add something from store to users cart
                    addToCart(items);
                }
                else if (user_choice == 4)
                {
                    //calls on remove from cart function to remove something from users cart
                    removeFromCart();
                }
                //displays users cart
                else if (user_choice == 5)
                {
                    //Reads data from file to provide the most updated info
                    string jsonStringFromFile = File.ReadAllText(@"data-files/data.txt");
                    List<List<List<string>>> profiles = JsonSerializer.Deserialize<List<List<List<string>>>>(jsonStringFromFile);
                    Console.WriteLine("Your Shopping Cart:");
                    for (int i = 0; i < profiles[index][1].ToArray().Length; i++)
                    {
                        Console.WriteLine(profiles[index][1][i]);
                    }
                }
                //breaks out of while loop to log out user
                else if (user_choice == 6)
                {
                    break;
                }
                //lets user know the choice they inputted was incorrect
                else
                {
                    Console.Write("That was not a valid choice!");
                }
            }
            //login function
            static void usercheck(List<List<List<string>>> profiles)
            {
            //part of the goto method used later on
            Found:
                bool userExists = false;
                while (!userExists)
                {
                    //creates lists that will be then added to the main profiles list
                    List<string> login = new List<string>();
                    List<string> cart = new List<string>();
                    List<List<string>> profile = new List<List<string>>();
                    //prompts user to choose between making a new profile or logging into an old one
                    Console.WriteLine("Enter 1 if you are a new user, enter 2 if you are an exisiting user: ");
                    string user = Console.ReadLine();
                    if (user == "1")
                    {
                        //prompts user to input there username and password of choosing
                        Console.WriteLine("Enter a username of your choosing: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter a Password of your choosing: ");
                        string password = Console.ReadLine();
                        for (int i = 0; i < profiles.ToArray().Length; i++)
                        {
                            //ensures no username is duplicated
                            if (profiles[i][0][0] == username)
                            {
                                Console.WriteLine(@$"Please try again this username is taken.");
                                //if this username already exists it takes user back to the beginning to try again
                                goto Found;
                            }
                        }
                        //adds user and password to a list
                        login.Add(username);
                        login.Add(password);
                        //adds the user and pass to a different list, along with another list that will eventually hold the users cart items
                        profile.Add(login);
                        profile.Add(cart);
                        profiles.Add(profile);
                        //Saves new info 
                        string jsonString = JsonSerializer.Serialize(profiles);
                        File.WriteAllText(@"data-files/data.txt", jsonString);
                        Console.WriteLine("Your account has been made please sign in now!");
                    }
                    else if (user == "2")
                    {
                        //prompts user to enter their existing username and password 
                        Console.WriteLine("Enter Username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter Password: ");
                        string password = Console.ReadLine();
                        for (int i = 0; i < profiles.ToArray().Length; i++)
                        {
                            //checks if the username and password are correct and exist
                            if (profiles[i][0][0] == username && profiles[i][0][1] == password)
                            {
                                //assigns value to global variable index
                                index = i;
                                Console.WriteLine(@$"Welcome {username} to the grocery store!");
                                //breaks out of while loop
                                userExists = true;
                            }
                        }
                        //notifies user if their user or pass is incorrect
                        if (!userExists)
                        {
                            Console.WriteLine("Your username or password is incorrect");
                        }
                    }
                }
            }
            //add to cart function responsible for user input number 3
            static void addToCart(String[] list)
            {
                //retrieves current info from file
                string jsonStringFromFile = File.ReadAllText(@"data-files/data.txt");
                List<List<List<string>>> profiles = JsonSerializer.Deserialize<List<List<List<string>>>>(jsonStringFromFile);
                List<string> shoppingCart = new List<string>();
                //prompts user to enter a product
                Console.Write(@"Please enter the name or product number, for the product you would like to add to your shopping cart: ");
                //converts user input to all lowercase
                string want = Console.ReadLine().ToLower();
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i].Contains(want) == true)
                    {
                        profiles[index][1].Add(list[i]);
                        Console.WriteLine($"{list[i]} has been added to your cart!");
                        //skips ahead in code if the item was found and added
                        goto FoundAlr;
                    }
                }
                //if item was not found it notifies user
                Console.WriteLine("This item was not found in our system.");
            FoundAlr:
                //converts info back so it can be added to data.txt and saved
                string jsonString = JsonSerializer.Serialize(profiles);
                File.WriteAllText(@"data-files/data.txt", jsonString);
            }
            //remove from cart function responsible for user input number 4
            static void removeFromCart()
            {
                //retrieves current info from file
                string jsonStringFromFile = File.ReadAllText(@"data-files/data.txt");
                List<List<List<string>>> profiles = JsonSerializer.Deserialize<List<List<List<string>>>>(jsonStringFromFile);
                //prompts user to enter a product
                Console.WriteLine(@"Please enter the name or product number, for the product you would like to remove from your shopping cart: ");
                //converts user input to all lowercase
                string remove = Console.ReadLine().ToLower();
                for (int i = 0; i < profiles[index][1].ToArray().Length; i++)
                {
                    if (profiles[index][1][i].Contains(remove) == true)
                    {
                        string removeTrue = profiles[index][1][i];
                        profiles[index][1].Remove(removeTrue);
                        Console.WriteLine($"{removeTrue} has been removed from your cart!");
                        //skips ahead in code if the item was found and added
                        goto FoundAlr;
                    }
                }
                Console.WriteLine("This item was not found in your cart.");
            //if item was not found it notifies user
            FoundAlr:
                //converts info back so it can be added to data.txt and saved
                string jsonString = JsonSerializer.Serialize(profiles);
                File.WriteAllText(@"data-files/data.txt", jsonString);
            }
        }
    }
}
