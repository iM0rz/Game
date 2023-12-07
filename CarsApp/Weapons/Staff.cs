namespace CarsApp.Weapons
{
    public class Staff : Weapon
    {
        public override string Hit()
        {
            return $"  используя посох на +{enchant} ";
        }

        public Staff(double pAtk, double mAtk, int enchant) : base(pAtk, mAtk, enchant)
        {
        }
    }
}