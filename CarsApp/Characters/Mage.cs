using System;
using CarsApp.Weapons;

namespace CarsApp
{
    public class Mage : Character
    {
        public override void Attack(Character target)
        {
            if (asleep)
            {
                Console.WriteLine($"Игрок с ником {name} находится под воздействием сна. Он пропускает ход. ");
                return;
            }
            
            bool useSleep = new Random().Next(0, 3) == 2;

            if (useSleep)
            {
                target.asleep = true;
                PrintSleep(target);
            }
            else
            {
                var dmg = CalculateDamage(target);
                bool miss = CalculateMiss();

                if (!miss && !asleep)
                {
                    target.GetDamage(dmg);
                }
            
                PrintHit(miss, target, dmg);
            }
        }

        protected override int CalculateDamage(Character target)
        {
            bool crit = new Random().Next(0, 3) == 2;
            var dmg = (int)((mAtk + weapon.mAtk) * (crit ? 1.3 : 1) - target.mDef);
            
            if (dmg <= 0)
            {
                dmg = 0;
            }

            return dmg;
        }

        private void PrintSleep(Character target)
        {
            Console.WriteLine($"====Маг с ником {name} применил слип на игрока {target.name}====");
        }
        
        protected override void PrintHit(bool miss, Character target, int dmg)
        {
            Console.WriteLine(miss
                ? $"====Маг с ником {name} промахивается по игроку {target.name}======"
                : $"====Маг с ником {name} кастует магию {weapon.Hit()} по игроку {target.name} нанося урон {dmg}======");
        }

        public Mage(int hp, int mp, string name, double pAtk, double mAtk, double pDef, double mDef, Weapon weapon, bool asleep, Guid id) : base(hp, mp, name, pAtk, mAtk, pDef, mDef, weapon, asleep, id)
        {
        }
    }
}