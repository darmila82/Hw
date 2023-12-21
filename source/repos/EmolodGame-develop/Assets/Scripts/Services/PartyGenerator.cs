using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Characters.Hero;
using Assets.Scripts.Entity.Characters.Hero.Type;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Services
{
    public class PartyGenerator
    {
        public List<Character> GeneratePlayerParty()
        {
            List<Character> characters = new List<Character>();

            characters.Add(new Tank());
            characters.Add(new DamageDealer());
            characters.Add(new Support());
            characters.Add(new Healer());

            return characters;
        }
    }
}
