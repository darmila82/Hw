using System;

namespace Assets.Scripts.Entity.Characters.Enemy.Type
{
    public class DamageDealerMorale : Enemy
    {
        public DamageDealerMorale(int level)
        {
            this.setupParams(
                name: "Enemy Antony",
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