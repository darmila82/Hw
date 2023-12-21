using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Assets.Scripts.Entity.Misc
{
    public class Preset
    {
        public enum EnemyRole
        {
            Tank = 1,
            DamageDealer = 2,
            DamageDealerMorale = 3,
            Healer = 4
        }

        private List<EnemyRole> enemyRoles = null;
        public Preset() 
        {
            this.enemyRoles = new List<EnemyRole>();
        }

        public Preset AddRole(EnemyRole role)
        {
            enemyRoles.Add(role);

            return this;
        }

        public List<EnemyRole> getList()
        {
            return enemyRoles;
        }
    }
}
