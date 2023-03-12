using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Microsoft.Office;

namespace ScrabbleLibrary
{
    internal class Rack : IRack
    {

        public Bag bag;
        public uint TotalPoints => RackPoints;

        public Application ap = new Application();

        public uint RackPoints;

        public List<Tile> tiles = new List<Tile>();

        public Rack(Bag b)
        {
            bag = b;
        }
        public uint AddTiles()
        {
            Random r = new Random();

            while (tiles.Count < 7)
            {
                int thisRandom = r.Next((int)bag.TileCount);
                tiles.Add(bag.tiles[thisRandom]);
                bag.tiles.RemoveAt(thisRandom);

                if (bag.TileCount == 0)
                {
                    break;
                }
            }

            return (uint)tiles.Count;
        }

        public bool PlayWord(string word)
        {
            uint points = 0;
            List<Tile> wordTiles = new List<Tile>();
            List<Tile> toRemove = new List<Tile>();

            // make a tile list for the word
            for (int i = 0; i < word.Length; i++)
            {
                Tile newTile = new Tile(word[i]);
                wordTiles.Add(newTile);
            }

            // find copies
            foreach (Tile tile in tiles)
            {
                for (int l = 0; l < wordTiles.Count; l++)
                {
                    if (tile.letter == wordTiles[l].letter && tile.tested == false)
                    {
                        tile.tested = true;
                        points += tile.value;
                        wordTiles.RemoveAt(l);
                        toRemove.Add(tile);
                    }
                }
            }

            for(int j = toRemove.Count - 1; j >= 0; --j)
            {
                tiles.Remove(toRemove[j]);
            }

            if (wordTiles.Count > 0)
            {
                points = 0;
                ap.Quit();
                return false;
            }
            else
            {
                RackPoints += points;
                AddTiles();
                return true;
            }

        }

        public uint TestWord(string word)
        {
            uint points = 0;
            List<Tile> wordTiles = new List<Tile>();
            List<Tile> copyTiles = new List<Tile>();
            copyTiles.AddRange(tiles);

            // make a tile list for the word
            for (int i = 0; i < word.Length; i++)
            {
                Tile newTile = new Tile(word[i]);
                wordTiles.Add(newTile);
            }

            // find copies
            foreach (Tile tile in copyTiles) 
            {
                for (int l = 0; l < wordTiles.Count; l++)
                {
                    if (tile.letter == wordTiles[l].letter && tile.tested == false)
                    {
                        points += tile.value;
                        wordTiles.RemoveAt(l);
                        tile.tested = true;
                    }
                }
            }

            // reset
            foreach (Tile tile in copyTiles)
            {
                tile.tested = false;
            }

            if (ap.CheckSpelling(word.ToLower()) == false || wordTiles.Count > 0)
            {
                points = 0;
                return points;
            }
            else
            {
                return points;
            }
        }

        public void GameOver()
        {
            ap.Quit();
        }

        public override string ToString()
        {
            string output = "[";
            for (int i = 0; i < tiles.Count; i++)
            {
                output += tiles[i].ToString();
            }

            return output + "]";
        }
    }
}
