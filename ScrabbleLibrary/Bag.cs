namespace ScrabbleLibrary
{
    public class Bag : IBag
    {
        public string Author => "Eden Tuck";
        public uint TileCount => (uint)tiles.Count;
        public Bag bag => new Bag();

        internal List<Tile> tiles = new List<Tile>();

        public Bag()
        {
            tiles.Add(new Tile('j', 8));
            tiles.Add(new Tile('k', 5));
            tiles.Add(new Tile('q', 10));
            tiles.Add(new Tile('x', 8));
            tiles.Add(new Tile('z', 10));

            for (int i = 0; i < 12; i++)
            {
                if (i < 2)
                {
                    tiles.Add(new Tile('b', 3));
                    tiles.Add(new Tile('c', 3));
                    tiles.Add(new Tile('f', 4));
                    tiles.Add(new Tile('h', 4));
                    tiles.Add(new Tile('m', 3));
                    tiles.Add(new Tile('p', 3));
                    tiles.Add(new Tile('v', 4));
                    tiles.Add(new Tile('w', 4));
                    tiles.Add(new Tile('y', 4));
                }
                if (i < 3)
                {
                    tiles.Add(new Tile('g', 2));
                }
                if (i < 4)
                {
                    tiles.Add(new Tile('d', 2));
                    tiles.Add(new Tile('l', 1));
                    tiles.Add(new Tile('s', 1));
                    tiles.Add(new Tile('u', 1));
                }
                if (i < 6)
                {
                    tiles.Add(new Tile('n', 1));
                    tiles.Add(new Tile('r', 1));
                    tiles.Add(new Tile('t', 1));
                }
                if (i < 8)
                {
                    tiles.Add(new Tile('o', 1));
                }
                if (i < 9)
                {
                    tiles.Add(new Tile('a', 1));
                    tiles.Add(new Tile('i', 1));
                }
                if (i < 12)
                {
                    tiles.Add(new Tile('e', 1));
                }
            }

        }

        public IRack GenerateRack()
        {
            Rack r = new(this);
            IRack rack = r;
            rack.AddTiles();
            return rack;
        }
        public override string ToString()
        {
            string finalOutput = "";
            #region "initalizing vars"
            int ac = 0;
            int bc = 0;
            int cc = 0;
            int dc = 0;
            int ec = 0;
            int fc = 0;
            int gc = 0;
            int hc = 0;
            int ic = 0;
            int jc = 0;
            int kc = 0;
            int lc = 0;
            int mc = 0;
            int nc = 0;
            int oc = 0;
            int pc = 0;
            int qc = 0;
            int rc = 0;
            int sc = 0;
            int tc = 0;
            int uc = 0;
            int vc = 0;
            int wc = 0;
            int xc = 0;
            int yc = 0;
            int zc = 0;
            #endregion
            for (int i = 0; i < tiles.Count; i++)
            {
                #region "if tiles[i].letter == thisletter"
                if (tiles[i].letter == 'a')
                {
                    ac++;
                }
                else if (tiles[i].letter == 'b')
                {
                    bc++;
                }
                else if (tiles[i].letter == 'c')
                {
                    cc++;
                }
                else if (tiles[i].letter == 'd')
                {
                    dc++;
                }
                else if (tiles[i].letter == 'e')
                {
                    ec++;
                }
                else if (tiles[i].letter == 'f')
                {
                    fc++;
                }
                else if (tiles[i].letter == 'g')
                {
                    gc++;
                }
                else if (tiles[i].letter == 'h')
                {
                    hc++;
                }
                else if (tiles[i].letter == 'i')
                {
                    ic++;
                }
                else if (tiles[i].letter == 'j')
                {
                    jc++;
                }
                else if (tiles[i].letter == 'k')
                {
                    kc++;
                }
                else if (tiles[i].letter == 'l')
                {
                    lc++;
                }
                else if (tiles[i].letter == 'm')
                {
                    mc++;
                }
                else if (tiles[i].letter == 'n')
                {
                    nc++;
                }
                else if (tiles[i].letter == 'o')
                {
                    oc++;
                }
                else if (tiles[i].letter == 'p')
                {
                    pc++;
                }
                else if (tiles[i].letter == 'q')
                {
                    qc++;
                }
                else if (tiles[i].letter == 'r')
                {
                    rc++;
                }
                else if (tiles[i].letter == 's')
                {
                    sc++;
                }
                else if (tiles[i].letter == 't')
                {
                    tc++;
                }
                else if (tiles[i].letter == 'u')
                {
                    uc++;
                }
                else if (tiles[i].letter == 'v')
                {
                    vc++;
                }
                else if (tiles[i].letter == 'w')
                {
                    wc++;
                }
                else if (tiles[i].letter == 'x')
                {
                    xc++;
                }
                else if (tiles[i].letter == 'y')
                {
                    yc++;
                }
                else if (tiles[i].letter == 'z')
                {
                    zc++;
                }
                #endregion
            }
            finalOutput += "a(" + ac + ")  b(" + bc + ")  c(" + cc + ")  d(" + dc + ")  e(" + ec + ")  f(" + fc + ")  g(" + gc +
                ")  h(" + hc + ")  i(" + ic + ")  j(" + jc + ")  k(" + kc + ")  l(" + lc + ")  m(" + mc + ")\nn(" + nc + ")  o(" +
                oc + ")  p(" + pc + ")  q(" + qc + ")  r(" + rc + ")  s(" + sc + ")  t(" + tc + ")  u(" + uc + ")  v(" + vc + ")  w(" +
                wc + ")  x(" + xc + ")  y(" + yc + ")  z(" + zc + ")";
            return finalOutput;
        }
    }
}