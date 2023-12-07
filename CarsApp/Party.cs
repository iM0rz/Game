using System.Linq;

namespace CarsApp
{
    public class Party
    {
        public Character[] Members;

        private Party(Character[] members)
        {
            this.Members = members;
        }
        
        public static Party CreateParty(int number)
        {
            var factory = new CharacterFactory();
            var p1 = factory.CreateCharacter(CharacterClass.Archer);
            p1.name = p1.name + "_" + number;
            
            var p2 = factory.CreateCharacter(CharacterClass.Warrior);
            p2.name = p2.name + "_" + number;
            
            var p3 = factory.CreateCharacter(CharacterClass.Mage);
            p3.name = p3.name + "_" + number;
            return new Party(new []
            {
               p1,p2,p3
            });
        }

        public bool IsInParty(Character character)
        {
            return Members.Contains(character);
        }
    }
}