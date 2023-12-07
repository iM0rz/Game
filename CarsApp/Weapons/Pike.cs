namespace CarsApp.Weapons
{
    public class Pike : Weapon
    {
        public Pike(double pAtk, double mAtk, int enchant) : base(pAtk, mAtk, enchant)
        {
        }

        public override string Hit()
        {
            return $" размахивает пикой на +{enchant} ";
        }

    }
}
