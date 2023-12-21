using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Skills;
using System;

namespace Assets.Scripts.Services.Skills.Strategy
{
    public class Buff : ISkillStrategy
    {
        Character targetCharacter = null;

        public Buff(TargetPosition targetPosition, Type type) 
        {
            if(type.Equals(typeof(Assets.Scripts.Entity.Characters.Hero.Hero)))
                this.targetCharacter = Singleton.getInstance().getHero(targetPosition);
            else
                this.targetCharacter = Singleton.getInstance().getEnemy(targetPosition);
        }

        public SkillResponse execute(Skill skill)
        {
            if (skill.getBuffs() != null)
                // TODO переписати addedBuffsSinglePerson, по іншому діставати enemy
                ExecuteSkillHelper.addedBuffsSinglePerson(skill.getBuffs(), targetCharacter, null);
            // TODO переписати SkillResponse під масові скіли
            return new SkillResponse("", ResponseType.Succsessed, ResultUsingSkill.Hit);
        }
    }
}
