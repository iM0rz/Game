namespace CarsApp.Weapons
{
    public class Sword : Weapon
    {
        public override string Hit()
        {
            return $" рубит с плеча мечом на +{enchant} ";
        }

        public Sword(double pAtk, double mAtk, int enchant) : base(pAtk, mAtk, enchant)
        {
        }
    }
}