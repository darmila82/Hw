using System;

namespace Assets.Scripts.Entity.Characters.Hero.Type
{
    public class DamageDealer : Hero
    {
        public DamageDealer()
        {
            this.setupParams(
                name: "Harut",
                healthPoint: 20,
                dodge: 10,
                defencePercent: 0,
                initiative: 15,
                accuracy: 10,
                criticalChance: 15,
                damage: 10);


        }
    }
}
