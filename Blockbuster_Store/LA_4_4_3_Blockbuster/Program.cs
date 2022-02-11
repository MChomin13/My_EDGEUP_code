using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_4_4_3_Blockbuster
{
    class Program
    {
        static Blockbuster blockBuster = new Blockbuster() { Address = "123 Mulberry Lane" };
        static VHSTape movie = new VHSTape();
        static void Main(string[] args)
        {
            Blockbuster blockBuster = new Blockbuster() { Address = "123 Mulberry Lane" };
            VHSTape movie = new VHSTape();
            int selection = 0;
            Console.WriteLine("Welcome to Blockbuster!");

            while (selection != 3)
            {
                Console.WriteLine(" 1 - Are you an employee?");
                Console.WriteLine(" 2 - Or, are you a customer?");
                Console.WriteLine(" 3 - Exit");
                selection = int.Parse(Console.ReadLine());
                Console.Write("Your selection is: {0} \n", selection);
                if (selection == 1)
                {
                    Employee(blockBuster);
                }
                else if (selection == 2)
                {
                    Customer(blockBuster);
                }
                else if (selection == 3)
                {
                    Console.WriteLine("Exiting Program. Have a nice day!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection\nPlease try again.");
                }
            }
        }
        static void Employee(Blockbuster blockBuster)
        {
            Console.WriteLine("What would you like to do? \n");
            int selection = 0;
            while (selection != 3)
            {
                Console.WriteLine(" 1 - Add a movie");
                Console.WriteLine(" 2 - Check inventory and status");
                Console.WriteLine(" 3 - Exit");
                selection = int.Parse(Console.ReadLine());
                Console.Write("Your selection is: {0} \n", selection);
                if (selection == 1)
                {
                    blockBuster.AddMovie();

                }
                else if (selection == 2)
                {
                    blockBuster.Inventory();
                    Console.WriteLine("\nWhat would you like to do now?");
                }
                else if (selection == 3)
                {
                    Console.WriteLine("Exiting To Main Menu.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection\nPlease try again.");
                }
            }
        }
        static void Customer(Blockbuster blockBuster)
        {
            VHSTape movie = new VHSTape();
            movie = null;
            Console.WriteLine("Thank you for choosing Blockbuster for your video rental needs!");
            Console.WriteLine("What would you like to do? \n");
            int selection = 0;
            while (selection != 4)
            {
                Console.WriteLine(" 1 - Rent a movie");
                Console.WriteLine(" 2 - Return a movie");
                Console.WriteLine(" 3 - Once you've picked a movie, Go home and watch");
                Console.WriteLine(" 4 - Exit");
                selection = int.Parse(Console.ReadLine());
                Console.Write("Your selection is: {0} \n", selection);
                if (selection == 1)
                {
                    movie = blockBuster.RentAMovie();
                    if (movie != null)
                    {
                        Console.WriteLine("Have a great day. Enjoy your movie!");  
                    } 
                }
                else if (selection == 2)
                {
                        Console.WriteLine("Which movie would you like to return?");
                        string name = Console.ReadLine();
                        blockBuster.ReturnTape(name);
                 }
                else if (selection == 3)
                {
                    if (movie != null)
                    {
                        Console.WriteLine(" -- Customer heads home with their rented movie and pops it into the VCR --");
                        VCR(movie);
                    }    
                    else
                        Console.WriteLine("You have not rented a movie yet");
                }
                else if (selection == 4)
                {
                    Console.WriteLine("Exiting To Main Menu.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection\nPlease try again.");
                }
            }
        }
        public static void VCR(VHSTape tape)
        {
            int selection = 0;
            while (selection != 3)
            {
                Console.WriteLine(" 1 - Play Movie");
                Console.WriteLine(" 2 - Rewind Movie");
                Console.WriteLine(" 3 - Return to Blockbuster");
                selection = int.Parse(Console.ReadLine());
                Console.Write("Your selection is: {0} \n", selection);
                if (selection == 1)
                {
                    Console.WriteLine("How many minutes of the movie would you like to watch?");
                    int amount = int.Parse(Console.ReadLine()); 
                    tape.PlayTape(amount);
                   // Console.WriteLine("Movie: {0}, Length: {1}, Status: {2} Played {3}", tape.Name, tape.Length, tape.IsRented, tape.PlayedLength);
                }
                else if (selection == 2)
                {
                    Console.WriteLine("How many minutes of the movie would you like to rewind?");
                    int amount = int.Parse(Console.ReadLine());
                    tape.RewindTape(amount);
                    //Console.WriteLine("Movie: {0}, Length: {1}, Status: {2} Played {3}", tape.Name, tape.Length, tape.IsRented, tape.PlayedLength);
                    Console.WriteLine("\nWhat would you like to do now?");
                }
                else if (selection == 3)
                {
                    Console.WriteLine("Returning to Blockbuster.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection\nPlease try again.");
                }
            }
        }
    }
}

