using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Form
{
    static class GameEngine
    {
        public static void SimulateRound(Unit[] units)
        {
            Map.round++;
            for (int i = 0; i < units.Length; i++)
            {
                if(Map.remUnits > 1 && units[i].Health > 0)
                {
                    units[i].SeekTarget(units);
                    if(!units[i].IsInRange() || units[i].Health < units[i].MaxHealth * 0.25)
                    {
                        units[i].Move();
                    }
                    else
                    {
                        units[i].Attack(units);
                    }
                }
            }
        }
    }
}
