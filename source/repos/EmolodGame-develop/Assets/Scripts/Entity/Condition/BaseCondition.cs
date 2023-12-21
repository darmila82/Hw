using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entity.Condition
{
    public class BaseCondition
    {
        protected string name = "";
        protected int maxDuration = 0;
        protected int currentDuration = 0;
        protected int chance = 0;

        public BaseCondition(string name, int maxDuration, int chance = 100) 
        {
            this.name = name;
            this.maxDuration = maxDuration;
            this.chance = chance;
        }

        public string getName() => name;
        public int getMaxDuration() => maxDuration;
        public int getCurrentDuration() => currentDuration;
        protected void updateCurrentDuration() => currentDuration = maxDuration;
        public int getChancePercent() => chance;
    }
}
