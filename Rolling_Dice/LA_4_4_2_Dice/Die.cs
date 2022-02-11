using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_4_4_2_Dice
{
    class Die
    {
        public int dieSides;
        public Die()
        {

        }
        public Die (int dS)
        {
            this.dieSides = dS;
        }
        public int DieSides
        { 
            get
            {
                return this.dieSides;
            }
            set
            {
                 this.dieSides = value;
            }
        }
        public int RollDice()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int rollValue = random.Next(1, this.dieSides+1);
            return rollValue;
        }
    }
}
