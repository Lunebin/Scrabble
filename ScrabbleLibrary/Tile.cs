using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleLibrary
{
    internal class Tile
    {
        public char letter = ' ';
        public uint value = 0;
        public bool tested { get; set;}

        public Tile(char l) { letter = l; }
        public Tile(char l, uint v)
        {
            this.letter = l;
            this.value = v;
        }

        public override string ToString()
        {
            return letter.ToString();
        }
    }
}
