using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Characters.Enemy.Type;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Services.Builders
{
    public class EnemyBuilder
    {
        List<Character> enemyParty = null;
        private int level = 1;

        public EnemyBuilder(int level = 1)
        {
            this.enemyParty = new List<Character>();
            this.level = level;
        }

        public EnemyBuilder createTank()
        {
            this.enemyParty.Add(new Tank(level));

            return this;
        }

        public EnemyBuilder createHealer()
        {
            this.enemyParty.Add(new Healer(level));

            return this;
        }

        public EnemyBuilder createDamageDealer()
        {
            this.enemyParty.Add(new DamageDealer(level));

            return this;
        }

        public EnemyBuilder createDamageDealerMorale()
        {
            this.enemyParty.Add(new DamageDealerMorale(level));

            return this;
        }

        public List<Character> getResult()
        {
            if (enemyParty.Count > 0)
                return enemyParty;

            throw new Exception("Empty party list");
        }
    }
}
