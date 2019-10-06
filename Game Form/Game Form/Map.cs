using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Game_Form
{
    static class Map
    {
        public static int round = 0;
        public static Random rnd = new Random();
        static char[,] map = new char[20, 20];
        static Unit[] units;
        static int tempX, tempY;
        public static int origUnits;
        public static int remUnits;

        public static void Randomize(int numUnits)
        {
            origUnits = numUnits;
            remUnits = numUnits;

            for(int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    map[x, y] = '~';
                }
            }

            units = new Unit[numUnits];

            for (int i = 0; i < numUnits; i++)
            {
                if(rnd.Next(0,2)==0)
                {
                    units[i] = new MeleeUnit();
                    do
                    {
                        tempX = rnd.Next(0, 20);
                        Debug.WriteLine(tempX);
                        tempY = rnd.Next(0, 20);
                        Debug.WriteLine(tempY);
                    } while (map[tempX, tempY] != '~');

                    units[i].XPos = tempX;
                    units[i].YPos = tempY;
                    map[tempX, tempY] = units[i].Sym;
                    Debug.WriteLine(map[tempX, tempY]);
                }
                else
                {
                    units[i] = new RangedUnit();
                    do
                    {
                        tempX = rnd.Next(0, 20);
                        Debug.WriteLine(tempX);
                        tempY = rnd.Next(0, 20);
                        Debug.WriteLine(tempY);
                    } while (map[tempX, tempY] != '~');

                    units[i].XPos = tempX;
                    units[i].YPos = tempY;
                    map[tempX, tempY] = units[i].Sym;
                    Debug.WriteLine(map[tempX, tempY]);
                }
            }
        }

        public static Label DrawMap(Label lbl)
        {
            lbl.Text = "";
            UpdateMap();
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    lbl.Text += " "+map[x, y]+" ";
                }
                lbl.Text += "\n";
            }

            return lbl;
        }

        public static void UpdateMap()
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    map[x, y] = '~';
                }
            }

            for (int i = 0; i < units.Length; i++)
            {
                if(units[i].Health > 0)
                {
                    map[units[i].XPos, units[i].YPos] = units[i].Sym;
                }
            }
        }

        public static RichTextBox SimulateRound(RichTextBox tb)
        {
            tb.Text = "";
            GameEngine.SimulateRound(units, map);
            foreach( Unit u in units )
            {
                tb.Text += u.ToString();
                if(u.ToString() != "")
                {
                    tb.Text += "\n";
                }
               
            }
            UpdateMap();
            return tb;
        }

        public static bool timeToStop()
        {
            int livingUnits = 0;

            foreach(Unit u in units)
            {
                if(u.Health > 0)
                {
                    livingUnits++;
                }
            }

            if(livingUnits <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
