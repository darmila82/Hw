using System;

namespace Assets.Scripts.Entity.Condition.State
{
    public class Bleed : BaseState
    {
        public Bleed(int duration, int power) : base("Кровотеча", duration, Type.Bleed, power)
        {
        }
    }
}
