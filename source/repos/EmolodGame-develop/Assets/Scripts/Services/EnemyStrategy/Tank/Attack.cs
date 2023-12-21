using Assets.Scripts.Entity.Characters.Enemy;
using Assets.Scripts.Entity.Condition.Buff;
using Assets.Scripts.Entity.Skills;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Services.EnemyStrategy.Tank
{
    internal class Attack
    {
        private Enemy enemy = null;
        public Attack(Enemy enemy) 
        {
            System.Threading.Thread.Sleep(1);
            Random random = new Random(DateTimeOffset.Now.Millisecond);

            this.enemy = enemy;
        }

        public void useSkill()
        {
            List<IUseSkill> skill = enemy.getAllSkills();

            Skill buffSkill = skill.Find(item => item.getSkillType() == SkillType.Buff).getSelf();

            /*if (enemy.checkTypeBuffs())
            {

            }*/
        }
    }
}
