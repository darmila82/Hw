using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Characters.Enemy;
using Assets.Scripts.Entity.Skills;
using System.Collections.Generic;

namespace Assets.Scripts.Services.Skills.Strategy
{
    public class MassAttack : ISkillStrategy
    {
        Character selectedCharacter = null;
        List<Character> enemyList = null;
        public MassAttack(Character selectedCharacter) 
        {
            this.selectedCharacter = selectedCharacter;

            // TODO Виправити типи на батьківські
            if (this.selectedCharacter.GetType().Equals(typeof(Assets.Scripts.Entity.Characters.Enemy.Enemy)))
            {
                enemyList = Singleton.getInstance().getHeroParty();
            }
            else
            {
                enemyList = Singleton.getInstance().getEnemyParty();
            }
        }

        public SkillResponse execute(Skill skill)
        {
            foreach (Enemy enemy in enemyList)
            {
                if (BattleHelper.IsHit(enemy.getDodge(), selectedCharacter.getAccuracy()))
                {
                    int damage = BattleHelper.calculateResultHit(skill.prepareValue(selectedCharacter.getFinalDamage()), enemy.getDefencePercent());

                    if (damage > 0)
                        enemy.decreaseHealthPoint(damage);

                    if (skill.getBuffs() != null)
                        ExecuteSkillHelper.addedBuffsSinglePerson(skill.getBuffs(), selectedCharacter, enemy);

                    if (skill.getStates() != null)
                        ExecuteSkillHelper.addedStateSinglePerson(skill.getStates(), enemy);

                    // TODO SkillResponse реалізувати для масових скілів
                }
                else
                {
                    // TODO SkillResponse реалізувати для масових скілів
                }
            }

            return new SkillResponse("", ResponseType.Succsessed, ResultUsingSkill.Hit); // Заглушка
        }
    }
}
