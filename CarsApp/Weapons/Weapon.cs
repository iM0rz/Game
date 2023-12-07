namespace CarsApp.Weapons
{
    public abstract class Weapon
    {
        public double pAtk;
        public double mAtk;
        public int enchant;

        public Weapon(double pAtk, double mAtk, int enchant)
        {
            this.enchant = enchant;
            this.pAtk = pAtk + enchant * (pAtk *0.1);
            this.mAtk = mAtk + enchant * (mAtk *0.1);
        }

        public abstract string Hit();
    }
}