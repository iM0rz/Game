using System;
using CarsApp.Weapons;

namespace CarsApp
{
    public class Warrior : Character
    {
        protected override int CalculateDamage(Character target)
        {
            var dmg = (int)(this.pAtk + weapon.pAtk - (target.pDef));

            if (dmg <= 0)
            {
                dmg = 0;
            }
            
            return dmg;
        }
        
        protected override void PrintHit(bool miss, Character target, int dmg)
        {
            Console.WriteLine(miss
                ? $"====Воин с ником {name} промахивается по игроку {target.name}======"
                : $"====Воин с ником {name} {weapon.Hit()} по игроку {target.name} нанося урон {dmg}======");
        }

        public Warrior(int hp, int mp, string name, double pAtk, double mAtk, double pDef, double mDef, Weapon weapon, bool asleep, Guid id) : base(hp, mp, name, pAtk, mAtk, pDef, mDef, weapon, asleep, id)
        {
        }
    }
}