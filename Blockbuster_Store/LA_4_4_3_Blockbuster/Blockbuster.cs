using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_4_4_3_Blockbuster
{
    class Blockbuster
    {
        //need address, list of movies
        //functions to: 1.add movie to store, 2.check if the movie exists based on name,3.check to see if the store has an unrented copy, based on name, 4. rent a movie, based on name... should return the VHSTape object 5. return the movie, based on name 6.a constructor that initalizes the store's address to a given value
        public string Address { get; set; }
        public Blockbuster()
        {

        }
        public Blockbuster(string address)
        {
            this.Address = address;
        }

        List<VHSTape> tapes = new List<VHSTape>();
        public void AddMovie()
        {
            Console.WriteLine("Please enter the name of the movie");
            string movieName = Console.ReadLine();
            Console.WriteLine("Please enter the length of the movie");
            int movieLength = int.Parse(Console.ReadLine());
            VHSTape tape1 = new VHSTape(movieName, movieLength);
            tapes.Add(tape1);
        }
        public void Inventory()
        {
            Console.WriteLine("These are the movies currently in the inventory:");
            if (tapes.Count == 0)
            {
                Console.WriteLine("The store is empty!");
            }
            else
            {
                foreach (VHSTape tape in tapes)
                {
                    string status;
                    if (tape.IsRented == false)
                        status = "Available";
                    else
                    {
                        status = "Rented";
                    }
                    Console.WriteLine("Movie: {0}, Length: {1}, Status: {2}", tape.Name, tape.Length, status);
                }
            }
        }
        public bool DoesMovieExist(string name)
        {
            foreach (VHSTape tape in tapes)
                if (tape.Name.ToUpper() == name.ToUpper())
                {
                    return true;
                }
            return false;
        }
        public bool IsMovieRented(string name)
        {
            foreach (VHSTape tape in this.tapes)
                if (tape.Name.ToUpper() == name.ToUpper())
                {
                    return tape.IsRented;
                }
            return false;
        }
        public VHSTape RentAMovie()
        {
            Console.WriteLine("Which movie would you like to rent?");
            string name = Console.ReadLine();
            Console.WriteLine("Let's see if that movie is in our inventory or not?");
            if (DoesMovieExist(name) == true)
            {
                Console.WriteLine("That is one of the movies in our inventory");
                Console.WriteLine("Let's check if that movie is available or not?");
                if (IsMovieRented(name) == false)
                {
                    Console.WriteLine("That movie is available to rent.");
                    
                    foreach (VHSTape tape in tapes)
                    {
                        if (tape.Name == name)
                        {
                            tape.IsRented = true;
                            Console.WriteLine("You have rented {0}", name);
                            return tape;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("That movie is unavailable at this time.");
                }
            }
            else if (DoesMovieExist(name) == false)
            {
                Console.WriteLine("It seems that we do not have this movie. Our apologies.\n Would you possibly like to check for a different movie?");
                return null;
            }
            return null;  
        }
        public VHSTape ReturnTape(string name)
        {
            foreach (VHSTape tape in tapes)
            {
                if (tape.Name == name && tape.IsRented == true)
                {
                    tape.IsRented = false;
                    if (tape.PlayedLength != 0)
                    {
                        Console.WriteLine("Next time, be kind and rewind!");
                    }
                    Console.WriteLine("Your movie has been returned.");
                }
               // else
               //     Console.WriteLine("That movie wasn't rented");
            }
            
            return null;

        }
    }
}