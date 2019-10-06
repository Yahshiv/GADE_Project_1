using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game_Form
{
    abstract class Unit
    {
        protected int xPos, yPos, health, maxHealth, speed, atk, team, xTarget, yTarget;
        protected double range;
        protected char sym;
        protected bool isInCombat;

        public Unit(int xPos, int yPos, int health, int speed, int atk, int team, double range, char sym, bool isInCombat)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.maxHealth = health;
            this.speed = speed;
            this.atk = atk;
            this.team = team;

            this.range = range;
            this.sym = sym;
            this.isInCombat = isInCombat;
            this.xTarget = 19;
            this.yTarget = 19;
        }

        public abstract void Move();
        public abstract void Attack(Unit[] units, char[,] map);
        public abstract bool IsInRange();
        public abstract void SeekTarget(Unit[] units);
        public abstract void Die(char[,] map);
        public abstract override string ToString();

        public abstract int XPos { get; set; }
        public abstract int YPos { get; set; }
        public abstract int Health { get; set; }
        public abstract int MaxHealth { get;  }
        public abstract int Speed { get; }
        public abstract int Atk { get; }
        public abstract int Team { get; }
        public abstract double Range { get; }
        public abstract char Sym { get; }
        public abstract bool IsInCombat { get; set; }

        public abstract int XTarget { get; set; }
        public abstract int YTarget { get; set; }

    }
}
