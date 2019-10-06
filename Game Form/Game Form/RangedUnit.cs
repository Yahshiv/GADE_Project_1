using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game_Form
{
    class RangedUnit : Unit
    {
        public RangedUnit() : base(0, 0, 9, 2, 3, 0, 3.9, 'R', false)
        {

        }

        public override int XPos
        {
            get => xPos;
            set => xPos = value;
        }
        public override int YPos
        {
            get => yPos;
            set => yPos = value;
        }
        public override int Health
        {
            get => health;
            set => health = value;
        }

        public override int Speed { get => speed;  }

        public override int Atk { get => atk; }

        public override int Team { get => team; }

        public override double Range { get => range; }

        public override char Sym { get => sym; }

        public override bool IsInCombat { get => isInCombat; set => isInCombat = value; }

        public override int XTarget
        {
            get => xTarget;
            set => xTarget = value;
        }
        public override int YTarget
        {
            get => yTarget;
            set => yTarget = value;
        }

        public override int MaxHealth { get => maxHealth; }

        public override void Attack(Unit[] units, char[,] map)
        {
            isInCombat = true;
            for (int i = 0; i < Map.origUnits; i++)
            {
                if (units[i].XPos == XTarget && units[i].YPos == YTarget && units[i].Health > 0)
                {
                    units[i].Health -= Atk;
                    if (units[i].Health <= 0 && /*units[i].*/IsInCombat)
                    {
                        units[i].Die(map);
                        Debug.WriteLine("================================ {0}", Map.remUnits);
                        /*units[i].*/IsInCombat = false;
                    }
                }
            }
        }

        public override void Die(char[,] map)
        {
            Map.remUnits--;
            map[xPos, yPos] = '~';
            Debug.WriteLine("remUnits: {0}, xPos: {1}, yPos: {2}", Map.remUnits, xPos, yPos);
        }

        public override bool IsInRange()
        {
            if (Math.Sqrt(Math.Pow(XPos - XTarget, 2) + Math.Pow(YPos - YTarget, 2)) <= Range)
            {
                Debug.WriteLine("IsInRange for Unit at {0}, {1} with Target {2}, {3}", XPos, YPos, XTarget, YTarget);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Move()
        {
            if(Map.round%Speed == 0)
            {
                if (Health >= maxHealth * 0.25)
                {
                    if (Math.Pow(XPos - XTarget, 2) >= Math.Pow(YPos - YTarget, 2))
                    {
                        Debug.WriteLine("Moving a Unit from: {0}, {1} towards: {2} {3}", XPos, YPos, XTarget, YTarget);
                        if (XPos - XTarget > 0)
                        {
                            XPos--;
                        }
                        else
                        {
                            XPos++;
                        }
                    }
                    else
                    {
                        if (YPos - YTarget > 0)
                        {
                            YPos--;
                        }
                        else
                        {
                            YPos++;
                        }
                    }
                }
                else
                {
                    if (xPos == 0 && yPos == 0) //top left corner
                    {
                        if (Map.rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            yPos++;
                        }
                    }
                    else if (xPos == 0 && yPos == 19) //bottom left corner
                    {
                        if (Map.rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            yPos--;
                        }
                    }
                    else if (xPos == 19 && yPos == 19) //bottom right corner
                    {
                        if (Map.rnd.Next(0, 2) == 0)
                        {
                            xPos--;
                        }
                        else
                        {
                            yPos--;
                        }
                    }
                    else if (xPos == 19 && yPos == 0) //top right corner
                    {
                        if (Map.rnd.Next(0, 2) == 0)
                        {
                            xPos--;
                        }
                        else
                        {
                            yPos++;
                        }
                    }
                    else if (xPos == 0) //left edge
                    {
                        if (Map.rnd.Next(0, 3) == 0)
                        {
                            xPos++;
                        }
                        else if (Map.rnd.Next(0, 2) == 0)
                        {
                            yPos++;
                        }
                        else
                        {
                            yPos--;
                        }
                    }
                    else if (yPos == 0) //top edge
                    {
                        if (Map.rnd.Next(0, 3) == 0)
                        {
                            yPos++; ;
                        }
                        else if (Map.rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            xPos--;
                        }
                    }
                    else if (xPos == 19) //right edge
                    {
                        if (Map.rnd.Next(0, 3) == 0)
                        {
                            xPos--;
                        }
                        else if (Map.rnd.Next(0, 2) == 0)
                        {
                            yPos++;
                        }
                        else
                        {
                            yPos--;
                        }
                    }
                    else if (yPos == 19) //bottom edge
                    {
                        if (Map.rnd.Next(0, 3) == 0)
                        {
                            yPos--;
                        }
                        else if (Map.rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            xPos--;
                        }
                    }
                    else
                    {
                        if ((Map.rnd.Next(0, 4) == 0))
                        {
                            yPos++;
                        }
                        else if (Map.rnd.Next(0, 3) == 0)
                        {
                            yPos--;
                        }
                        else if (Map.rnd.Next(0, 2) == 0)
                        {
                            xPos++;
                        }
                        else
                        {
                            xPos--;
                        }
                    }
                }
            }

            Map.UpdateMap();
        }

        public override void SeekTarget(Unit[] units)
        {
            double dist = 100;
            double temp;


            foreach(Unit u in units)
            {                
                if (u.Health > 0)
                {
                    /*if (xPos < 10)
                    {
                        if (yPos < 10)
                        {
                            XTarget = 19;
                            YTarget = 19;
                            //Debug.WriteLine("Quad: TL");
                        }
                        else
                        {
                            XTarget = 19;
                            YTarget = 0;
                            //Debug.WriteLine("Quad: BL");
                        }
                    }
                    else
                    {
                        if (yPos < 10)
                        {
                            XTarget = 0;
                            YTarget = 19;
                            //Debug.WriteLine("Quad: TR");
                        }
                        else
                        {
                            XTarget = 0;
                            YTarget = 0;
                            //Debug.WriteLine("Quad: BR");
                        }
                    }*/

                    temp = Math.Sqrt(Math.Pow(XPos - u.XPos, 2) + Math.Pow(YPos - u.YPos, 2));

                    if (temp != 0 && temp < dist)
                    {
                        dist = temp;
                        XTarget = u.XPos;
                        YTarget = u.YPos;
                        Debug.WriteLine("Target Acquired! at {0}, {1}", XTarget, YTarget);
                    }
                }
            }
        }

        public override string ToString()
        {
            if(Health <= 0)
            {
                return "";
            }
            else
            return "Position: "+XPos+", "+YPos+" | Health: "+Health+"/"+maxHealth+ " | Speed: " + Speed+ " | Attack" + Atk+ " | Range: " + Range+ " | Team: " + Team;
        }
    }
}
