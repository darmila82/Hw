

namespace Assets.Scripts.Entity.Condition.State
{
    public enum Type
    {
        Poison,
        Bleed,
        Stun
    }

    public class BaseState : BaseCondition
    {
        private Type type;
        private int power = 0;

        public BaseState(string name, int duration, Type type, int power) : base(name, duration)
        {
            this.type = type;
            this.power = power;
        }

        public int getPower() => power;
        public Type getType() => type;
    }
}
