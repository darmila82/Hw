using Assets.Scripts.Entity.Skills;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Entity.Characters.Hero
{
    public class Hero : Character
    {
        protected int morale = 0;
        public enum CharacterAttribute
        {
            HealthPoint,
            Dodge,
            DefencePercent,
            Initiative,
            Accuracy,
            CriticalChance,
            Damage
        }

        public enum CharacterAttributeModifierValue
        {
            HealthPoint = 5,
            Dodge = 1,
            DefencePercent = 1,
            Initiative = 2,
            Accuracy = 1,
            CriticalChance = 1,
            Damage = 3
        }

        public enum CharacterClass
        {
            Tank,
            Support,
            Healer,
            Rogue
        }

        protected int expirience = 0;
        protected int expirienceCup = 1000;
        protected Weapon weapon = null;
        protected Armor armor = null;
        protected List<CharacterAttribute> attributePerClass = null;
        

        public Hero() : base()
        {
            //Бонусний атрибут конкретного класа, для збільшення характеристик при левелАпі на х2
            this.attributePerClass = new List<CharacterAttribute>();
        }

        public override int getFinalDamage()
        {
            // Додати функціонал речей
            if (this.weapon != null)
            {
                return this.calculateBaseDamage(this.weapon.getDamage());
            }

            return this.calculateBaseDamage();
        }

        public int getFinalDefence()
        {
            if (this.armor != null)
            {
                return this.armor.getDefence() + this.defencePercent;
            }

            return this.defencePercent;
        }

        public List<IUseSkill> getActiveSkills()
        {
            return this.skills.FindAll(skill => skill.isActive() == true);
        }

        // Використання скіла гравця по конкретній цілі
        public void useSkill(TargetPosition targetPosition, int position)
        {
            // TODO переробити
            SkillResponse sr = this.skills[position].use(this, targetPosition);
        }

        public int getExpirience() => expirience;
        public void increaseExpirience(int expiriencePoint)
        {
            // TODO переписати
            if (this.level < 5)
            {
                if (expirienceCup * level >= expirience + expiriencePoint)
                {
                    this.levelUp();
                }
                else
                {
                    expirience += expiriencePoint;
                }
            } 
        }

        private int ImproveAttribute(CharacterAttributeModifierValue value, int multiplier)
        {
            return (int)value * multiplier;
        }

        private IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        // Логіка левелАпу, додавання до характеристик бонусів
        private void ImproveAttributes()
        {
            int[] multipliers = { 1, 1, 1, 1, 1, 1, 1 };

            foreach (var value in attributePerClass)
            {
                multipliers[(int)value] *= 2;
            }

            this.healthPointMax += ImproveAttribute(CharacterAttributeModifierValue.HealthPoint, multipliers[(int)CharacterAttribute.HealthPoint]);
            this.healthPoint = this.healthPointMax;
            this.dodge += ImproveAttribute(CharacterAttributeModifierValue.Dodge, multipliers[(int)CharacterAttribute.Dodge]);
            this.defencePercent += ImproveAttribute(CharacterAttributeModifierValue.DefencePercent, multipliers[(int)CharacterAttribute.DefencePercent]);
            this.accuracy += ImproveAttribute(CharacterAttributeModifierValue.Accuracy, multipliers[(int)CharacterAttribute.Accuracy]);
            this.criticalChance += ImproveAttribute(CharacterAttributeModifierValue.CriticalChance, multipliers[(int)CharacterAttribute.CriticalChance]);
            this.initiative += ImproveAttribute(CharacterAttributeModifierValue.Initiative, multipliers[(int)CharacterAttribute.Initiative]);
            this.damage += ImproveAttribute(CharacterAttributeModifierValue.Damage, multipliers[(int)CharacterAttribute.Damage]);          
        }

        private void levelUp()
        {
            this.level++;
            this.ImproveAttributes();
        }
        //---------Morale system--------------------------
        public void increaseMorale()
        {
            if (morale < 100)
            {
                morale += 5;
                if (morale >= 100)
                {
                    morale = 100;
                }
            }
        }
        public void decriaseMorale()
        {
            if (morale > -100)
            {
                morale -= 5;
                if (morale <= -100)
                {
                    morale = -100;
                }
            }
        }
        //set&get weapon&armor
        public void setWeapon(Weapon weapon)
        {
            this.weapon = weapon;
        }
        public Weapon getWeapon() 
        { 
            return this.weapon;
        }
        public void setArmor(Armor armor)
        {
            this.armor = armor;
        }
        public Armor getArmor()
        {
            return this.armor;
        }
    }
}
