using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CarsApp
{
    public class Game
    {
        public void Start()
        {
            var parties = new Party[]
            {
                Party.CreateParty(1),
                Party.CreateParty(2)
            };

            PrintParty(parties);

            var count = 0;
            while (true)
            {
                count++;
                var losersParty = CheckLose(parties);
                if (losersParty != null)
                {
                   PrintLosers(losersParty);
                   break;
                }   
                
                Console.WriteLine($"=====Ход №{count}=======");
                Fight(parties);
                Console.WriteLine("Итоги хода: ");
                PrintParty(parties);
            }
            
            Console.WriteLine("Игра окончена. ");
            Console.ReadLine();
        }

        private void PrintParty(Party[] parties)
        {
            int j = 1;
            foreach (var party in parties)
            {
                Console.WriteLine($"======ПАТИ № {j}======");
                j++;
                int i = 1;
                foreach (var member in party.Members)
                {
                    Console.WriteLine($"{i}. {member.name} HP : {member.hp}");
                    i++;
                }
            }
        }

        private void Fight(Party[] parties)
        {
            var aliveCharacters = FilterAlive(parties
                .SelectMany(x => x.Members).ToArray())
                .ToArray();

            foreach (var aliveCharacter in aliveCharacters)
            {
                aliveCharacter.asleep = false;
            }
            
            for (int i = 0; i < aliveCharacters.Length; i++)
            {
                var p1 = aliveCharacters[i];
                var p1Party = GetCharacterParty(p1, parties);
                var p2Party = parties.Except(new[] { p1Party }).First();
                var p2 = GetRandomCharacterFromParty(p2Party, aliveCharacters);

                p1.Attack(p2);

                if (!p2.alive)
                {
                    Console.BackgroundColor = System.ConsoleColor.Red;
                    Console.WriteLine($"===={p1.name} убил игрока {p2.name}");
                    Console.BackgroundColor = System.ConsoleColor.Black;
                }
            }
        }

        private Character GetRandomCharacterFromParty(Party party, Character[] aliveCharacters)
        {
            var alivePartyMembers = new List<Character>();
            foreach (var character in FilterAlive(aliveCharacters))
            {
                if (party.IsInParty(character))
                {
                    alivePartyMembers.Add(character);
                }
            }

            return alivePartyMembers[new Random().Next(0, alivePartyMembers.Count)];
        }

        private Party GetCharacterParty(Character character, Party[] parties)
        {
            foreach (var party in parties)
            {
                if (party.IsInParty(character))
                {
                    return party;
                }
            }

            return null;
        }
        
        private Character[] FilterAlive(Character[] characters)
        {
            var aliveMembers = new List<Character>();
            foreach (var member in characters)
            {
                if (!member.alive)
                {
                    continue;
                }

                aliveMembers.Add(member);
            }

            return aliveMembers.ToArray();
        }

        private void PrintLosers(Party losersParty)
        {
            Console.Write("Пати, состоящая из игроков: ");
            foreach (var member in losersParty.Members)
            {
                Console.Write($"{member.name}, ");
            }
            Console.WriteLine(" проиграла.");
        }

        private Party CheckLose(Party[] parties)
        {
            foreach (var party in parties)
            {
                var deathCount = 0;
                foreach (var member in party.Members)
                {
                    if (!member.alive)
                    {
                        deathCount++;
                    }
                }

                if (deathCount == party.Members.Length)
                {
                    return party;
                }
            }

            return null;
        }
    }
}