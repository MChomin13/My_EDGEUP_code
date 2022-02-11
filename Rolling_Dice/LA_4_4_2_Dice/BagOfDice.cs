using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LA_4_4_2_Dice
{
    class BagOfDice
    {
        static List<Die> diceBag = new List<Die>();
        public static void AddDice() //function to add dice to the pool
        {
            Console.WriteLine("How many dice would you like to add?");
            int numberDice = int.Parse(Console.ReadLine());
            Console.WriteLine("How many sides on these dice?");
            int numberSides = 0;
            bool validSides = false;
            do
            {
                string input = Console.ReadLine();
                numberSides = int.Parse(input);
                if (numberSides == 4 || numberSides == 6 || numberSides == 8 || numberSides == 10 || numberSides == 12 || numberSides == 20)
                {
                    validSides = true;
                    Console.WriteLine("You have chosen {0} sides.", numberSides);
                }
                else
                {
                    Console.WriteLine("You have chosen a size that does not exist\nPlease choose from (4/6/8/10/12/20).");
                }
            } while (!validSides);
            for (int i = 0; i < numberDice; i++)
            {
                Die die = new Die() { DieSides = numberSides };
                diceBag.Add(die);
                
            }
            Console.WriteLine("\n{0}d{1} have been added.", numberDice, numberSides);
            Console.WriteLine("\nWhat would you like to do now?");
        }
        public static void RemoveDice() //function to remove dice from the pool
        {
            Console.WriteLine("How many dice would you like to remove?");
            int diceRemove = int.Parse(Console.ReadLine());
            Console.WriteLine("How many sides do these dice have?");
            int sideRemove = int.Parse(Console.ReadLine());
            List<Die> removeDie = new List<Die>();
            int counter = 0;
            foreach (Die die in diceBag)
            {
                
                if (die.DieSides == sideRemove)
                {
                    removeDie.Add(die);
                    counter++;
                }
                if(counter == diceRemove)
                {
                    break;
                }
            }
            foreach (Die die in removeDie)
            {
                diceBag.Remove(die);  
            }

        }
        public static void ListDice() //function to list dice in the pool
        {
            Console.WriteLine("These are the dice in your bag currently:");
            if (diceBag.Count == 0)
            {
                Console.WriteLine("The bag is empty!");
            }
            else
            {
                foreach (Die die in diceBag)
                {
                    Console.WriteLine("d{0}", die.DieSides);
                }
            }
            Console.WriteLine("\nWhat would you like to do now?");
        }
        public static int RollDice() //function to roll dice in the pool
        {
            int sum = 0;
            if (diceBag.Count == 0)
            {
                Console.WriteLine("The bag is empty!\n");
                return sum;
            }
            else
            {
                Console.WriteLine("Rolling the dice!");
                
                foreach (Die die in diceBag)
                {
                    int rollValue = die.RollDice();
                    System.Threading.Thread.Sleep(20);
                    sum += rollValue;
                    Console.WriteLine("You rolled a {0} on your d{1}.", rollValue, die.DieSides);
                    Console.WriteLine("Your current total is {0}.\n", sum);
                }

                Console.WriteLine("Your final total is {0}.", sum);
                return sum;
            }
        }
    }  
}
