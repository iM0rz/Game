using System;
using CarsApp.Weapons;

namespace CarsApp
{
    public class CharacterFactory
    {
        static string GenerateRandomNickname()
        {
            string[] adjectives = { "Shadow", "Frost", "Sneaky", "Fire", "Ice", "Thunder", "Dragon", "Night", "Steel", "Rogue" };
            string[] nouns = { "Slayer", "Bite", "Ninja", "Storm", "Queen", "Bolt", "Rider", "Shade", "Spartan", "Assassin" };

            Random rnd = new Random();
            string nickname = adjectives[rnd.Next(adjectives.Length)] + nouns[rnd.Next(nouns.Length)];
            return nickname;
        }
        
        public Character CreateCharacter(CharacterClass characterClass)
        {
            var random = new Random();
            switch (characterClass)
            {
                case CharacterClass.Archer:
                {
                    return new Archer(
                        hp: random.Next(0, 1000),
                        mp: random.Next(0, 1000),
                        name: GenerateRandomNickname(),
                        pAtk: random.NextDouble() * 300,
                        mAtk: random.NextDouble() * 300,
                        pDef: random.NextDouble() * 300,
                        mDef: random.NextDouble() * 300,
                        weapon: new Bow(random.NextDouble() * 300, random.NextDouble() * 300, random.Next(0, 16)),
                        asleep: false,
                        id: Guid.NewGuid());
                } break;
                case CharacterClass.Mage:
                {
                    return new Mage(
                        hp: random.Next(0, 1000),
                        mp: random.Next(0, 1000),
                        name: GenerateRandomNickname(),
                        pAtk: random.NextDouble() * 300,
                        mAtk: random.NextDouble() * 300,
                        pDef: random.NextDouble() * 300,
                        mDef: random.NextDouble() * 300,
                        weapon: new Staff(random.NextDouble() * 300, random.NextDouble() * 300, random.Next(0, 16)),
                        asleep: false,
                        id: Guid.NewGuid());
                } break;
                case CharacterClass.Warrior:
                {
                    return new Warrior(
                        hp: random.Next(0, 1000),
                        mp: random.Next(0, 1000),
                        name: GenerateRandomNickname(),
                        pAtk: random.NextDouble() * 300,
                        mAtk: random.NextDouble() * 300,
                        pDef: random.NextDouble() * 300,
                        mDef: random.NextDouble() * 300,
                        weapon: new Sword(random.NextDouble() * 300, random.NextDouble() * 300, random.Next(0, 16)),
                        asleep: false,
                        id: Guid.NewGuid());
                } break;
            }

            return null;
        }
    }
}