using Assets.Scripts.Entity.Condition.Buff;
using Assets.Scripts.Entity.Condition.State;
using Assets.Scripts.Entity.Skills;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity.Characters
{
    abstract public class Character
    {
        protected int level = 1;
        protected int healthPoint = 0;
        protected int healthPointMax = 0;

        protected int dodge = 0;            //defence //buff
        protected int defencePercent = 0;   //defence //buff
        protected int initiative = 0;                 //buff
        protected int accuracy = 0;         //attack  //buff
        protected int criticalChance = 0;   //attack  //buff
        protected int damage = 0;           //attack  //buff

        protected int stunResist = 0;       //buff
        protected int poisonResist = 0;     //buff
        protected int bleedResist = 0;      //buff
        protected int debuffResist = 0;     //buff

        protected string name = string.Empty;
        protected string prefabName = string.Empty;

        protected List<BaseBuff> buffs = new List<BaseBuff>();
        protected List<BaseState> states = new List<BaseState>();
        protected List<IUseSkill> skills = null;

        public abstract int getFinalDamage();

        // Додавання параметрів бафів до базових характеристик
        private int calculateBuffValue(CharacterType type, int baseValue)
        {
            foreach (BaseBuff buff in buffs)
            {
                int value = 0;
                if((value = buff.getTypeValue(type)) != 0)
                    baseValue += (value * (int)buff.getType());
            }

            return baseValue;
        }

        public void addedSkill(IUseSkill skill)
        {
            this.skills.Add(skill);
        }

        public List<IUseSkill> getAllSkills()
        {
            return this.skills;
        }

        public Character()
        {
            this.skills = new List<IUseSkill>();
        }

        public void setPrefabName(string prefabName)
        {
            this.prefabName = prefabName;
        }

        public string getPrefabName()
        {
            return this.prefabName;
        }

        public void addState(BaseState state)
        {
            states.Add(state);
        }

        public List<BaseState> GetBaseStates() => states;

        public void addBuff(BaseBuff buff)
        {
            buffs.Add(buff);
        }
        public List<BaseBuff> GetBaseBuffs() => buffs;

        public bool checkTypeBuffs(CharacterType characterType)
        {
            if(this.buffs.Count == 0)
                return false;

            return buffs.Exists(buff => buff.checkTypes(characterType));
        }

        public void increaseHealthPoint(int healthPoint)
        {
            //TODO описати логіку
        }

        public void decreaseHealthPoint(int healthPoint)
        {
            //TODO описати логіку
        }

        protected int calculateBaseDamage(int additionalDamages = 0)
        {
            int value = additionalDamages + this.getDamage();

            if (Singleton.getInstance().getRandomNumber(1, 100) <= this.getCriticalChance())
            {
                return value + Singleton.getInstance().getRandomNumber(1, value);
            }

            return value;
        }

        public int getStunResist()
        {
            return this.calculateBuffValue(CharacterType.StunResist, stunResist);
        }

        public void setStunResist(int stunResist)
        {
            this.stunResist = stunResist;
        }

        public int getPoisonResist()
        {
            return this.calculateBuffValue(CharacterType.PoisonResist, poisonResist);
        }

        public void setPoisonResist(int poisonResist)
        {
            this.poisonResist = poisonResist;
        }

        public int getbleedResist()
        {
            return this.calculateBuffValue(CharacterType.BleedResist, bleedResist);
        }

        public void setbleedResist(int bleedResist)
        {
            this.bleedResist = bleedResist;
        }

        public int getdebuffResist()
        {
            return this.calculateBuffValue(CharacterType.DebuffResist, debuffResist);
        }

        public void setdebuffResist(int debuffResist)
        {
            this.debuffResist = debuffResist;
        }

        public int getLevel() 
        {
            return level;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setHealthPoint(int healthPoint)
        {
            this.healthPoint = healthPoint;
        }

        public int getDodge()
        {
            return this.calculateBuffValue(CharacterType.Dodge, dodge);
        }

        public void setDodge(int dodge)
        {
            this.dodge = dodge;
        }

        public int getDefencePercent()
        {
            return this.calculateBuffValue(CharacterType.DefencePercent, defencePercent);
        }

        public void setDeferencePercent(int defencePercent)
        {
            this.defencePercent = defencePercent;
        }

        public int getInitiative()
        {
            return this.calculateBuffValue(CharacterType.Initiative, initiative);
        }

        public void setInitiative(int initiative)
        {
            this.initiative = initiative;
        }

        public int getAccuracy()
        {
            return this.calculateBuffValue(CharacterType.Accuracy, accuracy);
        }

        public void setAccuracy(int accuracy)
        {
            this.accuracy = accuracy;
        }

        public int getCriticalChance()
        {
            return this.calculateBuffValue(CharacterType.CriticalChance, criticalChance);
        }

        public void setCriticalChance(int criticalChance)
        {
            this.criticalChance = criticalChance;
        }

        public int getDamage()
        {
            return this.calculateBuffValue(CharacterType.Damage, damage);
        }

        public void setDamage(int damage)
        {
            this.damage = damage;
        }

        public string getName() => name;
        public int getHealthPoint() => healthPoint;
        public int getHealthPointMax() => healthPointMax;
        public string getClassName()
        {
            return this.GetType().Name;
        }

        protected void setupParams(
            string name,
            int healthPoint,
            int dodge,
            int defencePercent,
            int initiative,
            int accuracy,
            int criticalChance,
            int damage
            )
        {
            this.name = name;
            this.healthPoint = healthPoint;
            this.healthPointMax = healthPoint;
            this.dodge = dodge;
            this.defencePercent = defencePercent;
            this.initiative = initiative;
            this.accuracy = accuracy;
            this.criticalChance = criticalChance;
            this.damage = damage;
        }
    }
}