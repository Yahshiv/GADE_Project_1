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
        public static int round = 0; //round counter
        public static Random rnd = new Random(); //general random
        static char[,] map = new char[20, 20]; //default map array
        static Unit[] units; //default unit array
        static int tempX, tempY; //temporary X and Y values
        public static int origUnits; //original number of units
        public static int remUnits; //remaining units

        public static void Randomize(int numUnits)//randomly populates units array with random units
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

        public static Label DrawMap(Label lbl)//returns a string formatted map
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

        public static void UpdateMap()//updates the map with spaces then units
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

        public static RichTextBox SimulateRound(RichTextBox tb)//round simulation
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

        public static bool timeToStop()//returns true when one unit remains
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
