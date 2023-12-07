namespace CarsApp.Weapons
{
    public class Bow : Weapon
    {
        public override string Hit()
        {
            return $" стреляет из лука на +{enchant} ";
        }

        public Bow(double pAtk, double mAtk, int enchant) : base(pAtk, mAtk, enchant)
        {
        }
    }
}