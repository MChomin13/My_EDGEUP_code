using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_4_4_3_Blockbuster
{
    class VHSTape
    {
        //need Name, Length, Whether or not it is rented, how far along it has been played
        //functions needed: play the tape a given amount, rewind the tape a given amount, set rental status, constructor to initialize the movie's name and length to given values... should initially not be rented and rewound
        public string Name { get; private set; }
        public int Length { get; set; }
        public int PlayedLength { get; set; }
        public bool IsRented { get; set; }

        public VHSTape()
        {

        }
        public VHSTape(string movieName, int movieLength)
        {
            this.Name = movieName;
            this.Length = movieLength;
            this.IsRented = false;
            this.PlayedLength = 0;
        }

    public int PlayTape(int amount)
        {
            this.PlayedLength += amount;
            if (this.PlayedLength >= this.Length)
            {
                Console.WriteLine("You've watched the whole movie");
                this.PlayedLength = this.Length;
            }
            else
            { 
              int timeRemaining = this.Length - this.PlayedLength;
                Console.WriteLine("You have {0} minutes remaining to watch of {1}.", timeRemaining, this.Name);
            }
            return PlayedLength;
        }
        public int RewindTape(int amount)
        {
            this.PlayedLength -= amount;
            if (this.PlayedLength < 0)
            {
                this.PlayedLength = 0;
            }
            return PlayedLength;
        }
    }
}