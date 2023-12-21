using System;

namespace Assets.Scripts.Entity.Characters.Enemy.Type
{
    internal class Healer : Enemy
    {
        public Healer(int level)
        {
            this.setupParams(
                name: "Enemy Jake",
                healthPoint: 12,
                dodge: 10,
                defencePercent: 0,
                initiative: 2,
                accuracy: 8,
                criticalChance: 15,
                damage: 3);
        }
    }
}
