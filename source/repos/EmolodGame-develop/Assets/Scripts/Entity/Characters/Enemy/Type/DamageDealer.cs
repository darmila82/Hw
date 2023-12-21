using System;

namespace Assets.Scripts.Entity.Characters.Enemy.Type
{
    internal class DamageDealer : Enemy
    {
        public DamageDealer(int level)
        {
            this.setupParams(
                name: "Enemy Vergil",
                healthPoint: 25,
                dodge: 5,
                defencePercent: 5,
                initiative: 10,
                accuracy: 8,
                criticalChance: 5,
                damage: 15);
        }
    }
}
