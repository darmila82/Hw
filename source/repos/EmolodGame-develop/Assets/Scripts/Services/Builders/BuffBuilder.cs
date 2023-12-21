using Assets.Scripts.Entity.Condition.Buff;
using System;

namespace Assets.Scripts.Services.Builders
{
    public class BuffBuilder
    {
        private BaseBuff buff = null;

        private void createNewEffect(CharacterType characterType, int value)
        {
            buff.addNewValue(characterType, value * (int)buff.getType());
        }

        public BuffBuilder() { }

        public BuffBuilder createBuff(string name, int duration)
        {
            buff = new BaseBuff(name, duration);
            
            return this;
        }

        public BuffBuilder createDebuff(string name, int duration, int chance)
        {
            buff = new BaseBuff(name, duration, chance, Entity.Condition.Buff.Type.Debuff);
            return this;
        }

        public BuffBuilder addDodge(int value)
        {
            createNewEffect(CharacterType.Dodge, value);

            return this;
        }

        public BuffBuilder addDefencePercent(int value)
        {
            createNewEffect(CharacterType.DefencePercent, value);

            return this;
        }
        
        public BuffBuilder addInitiative(int value)
        {
            createNewEffect(CharacterType.Initiative, value);

            return this;
        }

        public BuffBuilder addAccuracy(int value)
        {
            createNewEffect(CharacterType.Accuracy, value);

            return this;
        } 

        public BuffBuilder addCriticalChance(int value)
        {
            createNewEffect(CharacterType.CriticalChance, value);

            return this;
        }

        public BuffBuilder addDamage(int value)
        {
            createNewEffect(CharacterType.Damage, value);

            return this;
        }

        public BaseBuff getResult()
        {
            return buff;
        }
    }
}
