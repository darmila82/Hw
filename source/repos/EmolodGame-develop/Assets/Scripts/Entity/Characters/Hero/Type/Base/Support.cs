using System;

namespace Assets.Scripts.Entity.Characters.Hero.Type
{
    public class Support : Hero
    {
        public Support()
        {
            this.setupParams(
                name: "Gary",
                healthPoint: 30,
                dodge: 2,
                defencePercent: 3,
                initiative: 8,
                accuracy: 5,
                criticalChance: 5,
                damage: 4);

            this.attributePerClass.Add(CharacterAttribute.Dodge);
            this.attributePerClass.Add(CharacterAttribute.HealthPoint);

        }
    }
}
