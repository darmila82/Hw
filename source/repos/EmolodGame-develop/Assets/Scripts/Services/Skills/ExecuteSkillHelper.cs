using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Characters.Enemy;
using Assets.Scripts.Entity.Characters.Hero;
using Assets.Scripts.Entity.Condition.Buff;
using Assets.Scripts.Entity.Condition.State;
using System.Collections.Generic;

namespace Assets.Scripts.Services.Skills
{
    public class ExecuteSkillHelper
    {
        // TODO Розложити по функціям.
        public static void addedBuffsSinglePerson(List<BaseBuff> baseBuffs, Character hero, Character enemy)
        {
            foreach (BaseBuff baseBuff in baseBuffs)
            {
                if (baseBuff.getType() == Entity.Condition.Buff.Type.Buff)
                {
                    hero.addBuff(baseBuff);
                } else
                {
                    if (enemy.getdebuffResist() <= baseBuff.getChancePercent())
                    {
                        enemy.addBuff(baseBuff);
                    }
                    
                }
            }
            // TODO Повертати інформацію про успішне накидування дебафа
        }

        public static void addedStateSinglePerson(List<BaseState> baseStates, Character character)
        {
            foreach (BaseState state in baseStates)
            {
                if (getResist(character, state.getType())  <= state.getChancePercent())
                {
                    character.addState(state);
                }
            }
        }

        private static int getResist(Character character, Entity.Condition.State.Type type)
        {
            if (type == Entity.Condition.State.Type.Poison)
            {
                return character.getPoisonResist();
            } 
            else if (type == Entity.Condition.State.Type.Bleed)
            {
                return character.getbleedResist();
            }
            else if (type == Entity.Condition.State.Type.Stun)
            {
                return character.getStunResist();
            }

            return 0;
        }
    }
}
