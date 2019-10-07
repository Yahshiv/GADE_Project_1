using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game_Form
{
    static class GameEngine
    {
        public static void SimulateRound(Unit[] units, char[,] map)//each game round
        {
            Map.round++;
            for (int i = 0; i < units.Length; i++)
            {
                if(Map.remUnits > 1 && units[i].Health > 0)
                {
                    units[i].SeekTarget(units);
                    if(units[i].IsInRange() && units[i].Health >= units[i].MaxHealth * 0.25)
                    {
                        units[i].Attack(units, map);
                        Debug.WriteLine("Unit {0} is attacking", i);
                    }
                    else
                    {
                        Debug.WriteLine("Moving unit {0}", i);
                        units[i].Move();
                    }
                }
            }
        }
    }
}
