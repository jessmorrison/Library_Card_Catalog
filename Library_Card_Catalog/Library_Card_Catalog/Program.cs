using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCardCatalog
{

    class Program
    {
        static void Main(string[] args)
        {
            string fileName = SetFileName();
            CardCatalog cc = new CardCatalog(fileName);
            string result = "";
            while (result != "3")
            {
                Console.Clear();

                Console.WriteLine("Greetings, \n\n");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1) List All Books");
                Console.WriteLine("2) Add a Book");
                Console.WriteLine("3) Save and Exit");

                result = Console.ReadLine();
                if (result == "1")
                {
                    
                        cc.ListBooks("");
                   
                }
                if (result == "2")
                {

                    cc.AddBook("");
                }
                if (result == "3")
                {
                    cc.Save();
                }
            }
            Console.ReadLine();
        }

        private static string SetFileName()
        {
            string Username;
            Console.WriteLine("Welcome, Please enter a username: ");
            Username = (Console.ReadLine());
            return Username;
        }
    }




}
