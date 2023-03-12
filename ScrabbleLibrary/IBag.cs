using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleLibrary
{
    public interface IBag
    {
        string Author { get; }
        uint TileCount { get; }

        IRack GenerateRack();
        string ToString();
    }
}
