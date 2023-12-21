using System;

namespace Assets.Scripts.Entity.Characters.Hero.Type
{
    public class Tank : Hero
    {
        public Tank() : base()
        {
            this.setupParams(
                name: "Reynar",
                healthPoint: 50,
                dodge: 3,
                defencePercent: 20,
                initiative: 10,
                accuracy: 7,
                criticalChance: 0,
                damage: 10);
        }
    }
}
