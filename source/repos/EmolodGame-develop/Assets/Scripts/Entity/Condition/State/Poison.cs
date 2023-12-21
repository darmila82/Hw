using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entity.Condition.State
{
    public class Poison :BaseState
    {
        public Poison(int duration, int power) : base("Отрава", duration, Type.Poison, power)
        {
        }
    }
}
