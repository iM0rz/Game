using System;
using CarsApp.Weapons;

namespace CarsApp
{
    public abstract class Character
    {
        public int hp;
        protected double mAtk;
        public double mDef;
        protected int mp;
        public string name;
        protected double pAtk;
        public double pDef;
        protected Weapon weapon;
        public bool alive;
        public bool asleep;
        public Guid id;

        public Character(int hp, int mp, string name, double pAtk, double mAtk, double pDef, double mDef, Weapon weapon, bool asleep, Guid id)
        {
            this.hp = hp;
            this.mp = mp;
            this.name = name;
            this.pAtk = pAtk;
            this.mAtk = mAtk;
            this.pDef = pDef;
            this.mDef = mDef;
            this.weapon = weapon;
            this.asleep = asleep;
            this.id = id;
            this.alive = true;
        }

        public void GetDamage(int value)
        {
            int hpAfterDamage = hp - value;
            if (hpAfterDamage <= 0)
            {
                hp = 0;
                alive = false;
            }
            else
            {
                hp = hpAfterDamage;
            }
        }
        
        public virtual void Attack(Character target)
        {
            if (asleep)
            {
                Console.WriteLine($"Игрок с ником {name} находится под воздействием сна. Он пропускает ход. ");
                return;
            }
            
            var dmg = CalculateDamage(target);
            bool miss = CalculateMiss();

            if (!miss && !asleep)
            {
                target.GetDamage(dmg);
            }
            
            PrintHit(miss, target, dmg);
        }

        protected abstract int CalculateDamage(Character target);
        protected abstract void PrintHit(bool miss, Character target, int dmg);

        protected bool CalculateMiss()
        {
            Random rand = new Random();
            return rand.Next(0, 5) == 4;
        }
    }
}