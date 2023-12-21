using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Condition.Buff;
using Assets.Scripts.Entity.Condition.State;
using Assets.Scripts.Services.Skills;
using Assets.Scripts.Services.Skills.Strategy;
using System.Collections.Generic;

namespace Assets.Scripts.Entity.Skills
{
    public enum TargetPosition
    {
        All = -1,
        First,
        Second,
        Third,
        Middle
    }

    public enum TargetType
    {
        Single = 1,
        Massive
    }

    public enum SkillType
    {
        Buff,
        MassBuff,
        Debuff,
        MassDebuff,
        Attack,
        MassAttack,
        Healing,
        MassHealing
    }

    public class Skill : IUseSkill
    {
        protected string name = string.Empty;
        protected bool active = false;
        protected int percentPower = 0;
        protected SkillType type;
        protected TargetType targetType;
        // Приорітет використання скіла ворогом
        protected int priority = 0;

        protected List<BaseBuff> buffList = null;
        protected List<BaseState> stateList = null;

        public void setPriority(int priority)
        {
            if(priority > 100)
                this.priority = 100;
            else 
                this.priority = priority;
        }

        public int getPriority() { return priority; }

        public void addBuff(BaseBuff baseBuff)
        {
            if (buffList == null)
            {
                buffList = new List<BaseBuff>();
            }

            buffList.Add(baseBuff);
        }

        public List<BaseBuff> getBuffs()
        {
            return this.buffList;
        }

        public void addState(BaseState baseState)
        {
            if (stateList == null)
            {
                stateList = new List<BaseState>();
            }

            stateList.Add(baseState);
        }

        public List<BaseState> getStates()
        {
            return this.stateList;
        }

        public Skill getSelf() { return this; }

        public void setName(string name) => this.name = name;
        public string getName() => this.name;

        public void setActive(bool active) => this.active = active;
        public bool isActive() => this.active;

        public void setSkillType(SkillType skillType) => this.type = skillType;
        public SkillType getSkillType() => this.type;

        public int getPercentPower() => this.percentPower;

        public void setPercentPower(int percentPower) => this.percentPower = percentPower;

        public int prepareValue(int value)
        {
            return (int)((double)value / 100.00 * this.percentPower);
        }

        public SkillResponse use(Character character, TargetPosition targetPosition)
        {
            ISkillStrategy strategy = null;

            if (SkillType.Attack == this.getSkillType())
            {
                strategy = new Attack(character, targetPosition);
            } 
            else if (SkillType.MassAttack == this.getSkillType())
            {
                strategy = new MassAttack(character);
            } else if (SkillType.Buff == this.getSkillType())
            {
                strategy = new Buff(targetPosition, character.GetType());
            }
            // TODO Продовжити створювати стратегії

            strategy.execute(this);

            return new SkillResponse("", ResponseType.Succsessed, ResultUsingSkill.Hit);
        }

        public Skill(string name, SkillType type, TargetType targetType = TargetType.Single, int percentPower = 0, bool active = false)
        {
            this.name = name;
            this.active = active;
            this.type = type;
            this.percentPower = percentPower;
            this.targetType = targetType;
        }
    }
}
