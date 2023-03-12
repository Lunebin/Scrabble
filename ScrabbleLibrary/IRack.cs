using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleLibrary
{
    public interface IRack
    {
        uint TotalPoints { get; }

        uint TestWord(string word);
        bool PlayWord(string word);
        uint AddTiles();
        string ToString();
        void GameOver();
    }
}
