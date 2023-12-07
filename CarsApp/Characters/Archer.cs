using System;
using CarsApp.Weapons;

namespace CarsApp
{
    public class Archer : Character
    {
        protected override int CalculateDamage(Character target)
        {
            bool crit = new Random().Next(0, 3) == 2;
            var dmg = (int)((pAtk + weapon.pAtk) * (crit ? 1.3 : 1) - target.pDef);

            if (dmg <= 0)
            {
                dmg = 0;
            }

            return dmg;
        }
        
        protected override void PrintHit(bool miss, Character target, int dmg)
        {
            Console.WriteLine(miss
                ? $"====Лучник с ником {name} промахивается по игроку {target.name}======"
                : $"====Лучник с ником {name} {weapon.Hit()} по игроку {target.name} нанося урон {dmg}======");
        }

        public Archer(int hp, int mp, string name, double pAtk, double mAtk, double pDef, double mDef, Weapon weapon, bool asleep, Guid id) : base(hp, mp, name, pAtk, mAtk, pDef, mDef, weapon, asleep, id)
        {
        }
    }
}