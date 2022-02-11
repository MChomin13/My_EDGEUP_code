using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_4_4_2_Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            Console.WriteLine("Welcome to the Matt's Magical Dice!");
            Console.WriteLine("What would you like to do? \n");
            while (selection != 3)
            {
                Console.WriteLine(" 1 - Roll a single die");
                Console.WriteLine(" 2 - Roll a bunch of dice");
                Console.WriteLine(" 3 - Exit");
                selection = int.Parse(Console.ReadLine());
                Console.Write("Your selection is: {0} \n", selection);
                if (selection == 1)
                {
                    SingleDie();
                }
                else if (selection == 2)
                {

                    MultipleDice();
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

            Console.Read();

        }
        static void SingleDie()
        {
            int numberSides = 0;
            bool validSides = false;
            do
            {
                Console.WriteLine("Enter the number of sides your die has. (4/6/8/10/12/20)");
                string input = Console.ReadLine();
                numberSides = int.Parse(input);
                if (numberSides == 4 || numberSides == 6 || numberSides == 8 || numberSides == 10 || numberSides == 12 || numberSides == 20)
                {
                    validSides = true;
                    Console.WriteLine("You have chosen a die with {0} sides", numberSides);   
                }
                else 
                {
                    Console.WriteLine("You have chosen a size that does not exist\nPlease choose from (4/6/8/10/12/20).");
                }
            } while (!validSides);
            Die die = new Die() { DieSides = numberSides };
            Console.WriteLine("Rolling this die! ");
            int rollValue = die.RollDice();
            Console.WriteLine("You rolled a {0}.", rollValue);
            bool check = false;
            Console.WriteLine("Would you like to roll this die again? Y / N");
            do
            {
                string option;
                option = Console.ReadLine();
                if (option == "Y" || option == "y")
                {
                    check = false;
                    Console.WriteLine("Rolling again!");
                    rollValue = die.RollDice();
                    Console.WriteLine("You rolled a {0} this time.", rollValue);
                    Console.WriteLine("Would you like to roll this die again? Y / N");
                }
                else if (option == "N" || option == "n")
                {
                    check = true;
                    Console.WriteLine("Rolling complete.\nReturning to main menu.\nWhat would you like to do now?\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input\nWould you like to roll this die again? Y / N");
                }
            } while (check == false);
        }
        static void MultipleDice()
        {
                int selection = 0;
                Console.WriteLine("What would you like to do? \n");
                while(selection !=5)
                { 
                    Console.WriteLine(" 1 - Add a/some die/dice to the bag");
                    Console.WriteLine(" 2 - Remove a/some die/dice from the bag");
                    Console.WriteLine(" 3 - Show all the dice in the bag");
                    Console.WriteLine(" 4 - Roll all the dice in the bag");
                    Console.WriteLine(" 5 - Exit to main menu");
                    selection = int.Parse(Console.ReadLine());
                    Console.Write("Your selection is: {0} \n", selection);
                    if (selection == 1)
                    {
                        BagOfDice.AddDice();
                    }
                    else if (selection == 2)
                    {
                        BagOfDice.RemoveDice();
                    }
                    else if (selection == 3)
                    {
                        BagOfDice.ListDice();
                    }
                    else if (selection == 4)
                    {
                        BagOfDice.RollDice();
                    }
                    else if (selection == 5)
                    {
                        Console.WriteLine("Returning to main menu.\nWhat would you like to do now?\n");
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