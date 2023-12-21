using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity.Condition.Buff
{
    public enum CharacterType
    {
        Dodge,
        DefencePercent,
        Initiative,
        Accuracy,
        CriticalChance,
        Damage,
        StunResist,
        PoisonResist,
        BleedResist,
        DebuffResist
    }

    public enum Type
    {
        Debuff = -1,
        Buff = 1
    }

    public class BaseBuff : BaseCondition
    {
        Dictionary<CharacterType, int> types = null;
        Type type;

        public BaseBuff(string name, int duration, int chance = 100, Type type = Type.Buff) : base(name, duration, chance)
        {
            this.type = type;
        }

        public Type getType() => this.type;

        //Один баф може збільшувати кілька характеристик
        public void addNewValue(CharacterType type, int value)
        {
            if(types == null)
                types = new Dictionary<CharacterType, int>();

            types.Add(type, value); 
        }

        public Dictionary<CharacterType, int> getTypes() { return types; }

        public bool checkTypes(CharacterType type)
        {
            return types.ContainsKey(type);
        }

        public int getTypeValue(CharacterType type)
        {
            if (types != null)
                if(this.types.ContainsKey(type))
                    return this.types[type];
                else 
                    return 0;
            else
                throw new System.Exception("Пустий масив");
        }
    }
}
