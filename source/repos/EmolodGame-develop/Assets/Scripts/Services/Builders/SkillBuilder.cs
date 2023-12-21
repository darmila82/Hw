using Assets.Scripts.Entity.Condition.Buff;
using Assets.Scripts.Entity.Condition.State;
using Assets.Scripts.Entity.Skills;
using Unity.VisualScripting;

namespace Assets.Scripts.Services.Builders
{
    public class SkillBuilder
    {
        private Skill skill = null; 
        public SkillBuilder() { }

        public SkillBuilder initSingleSkill(string name, SkillType type)
        {
            this.skill = new Skill(name, type);

            return this;
        }
        public SkillBuilder initMassiveSkill(string name, SkillType type)
        {
            this.skill = new Skill(name, type, TargetType.Massive);

            return this;
        }

        public SkillBuilder setPercentPower(int power = 100)
        {
            this.skill.setPercentPower(power);

            return this;
        }

        public SkillBuilder setPriority(int priority = 1)
        {
            this.skill.setPriority(priority);

            return this;
        }

        public SkillBuilder makeActive()
        {
            this.skill.setActive(true);

            return this;
        }

        public SkillBuilder addBuff(BaseBuff buff)
        {
            this.skill.addBuff(buff);

            return this;
        }

        public SkillBuilder addPoison(int duration, int power)
        {
            this.skill.addState(new Poison(duration, power));

            return this;
        }

        public SkillBuilder addBleed(int duration, int power)
        {
            this.skill.addState(new Bleed(duration, power));

            return this;
        }

        public Skill getResult()
        {
            return this.skill;
        }
    }
}
