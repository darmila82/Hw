using System;

namespace Assets.Scripts.Entity.Characters.Hero.Type
{
    public class Healer : Hero
    {
        public Healer() {
            this.setupParams(
                name: "Elnur",
                healthPoint: 20,
                dodge: 5,
                defencePercent: 0,
                initiative: 12,
                accuracy: 9,
                criticalChance: 5,
                damage: 3);


        }
    }
}
