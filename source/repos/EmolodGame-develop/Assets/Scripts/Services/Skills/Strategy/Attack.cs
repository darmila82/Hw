using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Characters.Enemy;
using Assets.Scripts.Entity.Characters.Hero;
using Assets.Scripts.Entity.Condition.State;
using Assets.Scripts.Entity.Skills;
using System.Collections.Generic;

namespace Assets.Scripts.Services.Skills.Strategy
{
    public class Attack : ISkillStrategy
    {
        private Character selectedCharacter = null;
        private Character targetCharacter = null;
        public Attack(Character selectedCharacter, TargetPosition targetPosition) 
        {
            this.selectedCharacter = selectedCharacter;
            this.targetCharacter = Singleton.getInstance().getEnemy(targetPosition);
        }

        public SkillResponse execute(Skill skill)
        {
            SkillResponse skillResponse = null;

            if (BattleHelper.IsHit(targetCharacter.getDodge(), selectedCharacter.getAccuracy()))
            {
                int damage = BattleHelper.calculateResultHit(skill.prepareValue(selectedCharacter.getFinalDamage()), targetCharacter.getDefencePercent());

                if (damage > 0)
                    targetCharacter.decreaseHealthPoint(damage);

                if (skill.getBuffs() != null)
                    ExecuteSkillHelper.addedBuffsSinglePerson(skill.getBuffs(), selectedCharacter, targetCharacter);

                if (skill.getStates() != null)
                    ExecuteSkillHelper.addedStateSinglePerson(skill.getStates(), targetCharacter);

                skillResponse = new SkillResponse("", ResponseType.Succsessed, ResultUsingSkill.Hit);
            }
            else
            {
                skillResponse = new SkillResponse("", ResponseType.Succsessed, ResultUsingSkill.Missed);
            }

            return skillResponse;
        }
    }
}
