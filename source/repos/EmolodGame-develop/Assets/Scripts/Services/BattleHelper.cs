using System;
using System.Collections.Generic;

namespace Assets.Scripts.Services
{
    internal class BattleHelper
    {
        public static bool IsHit(int dodge, int accuracy)
        {
            if (((double)accuracy / (double)(dodge + accuracy)) * 100 <= Singleton.getInstance().getRandomNumber(1, 100))
            {
                return true;
            }

            return false;
        }

        public static int calculateResultHit(int damage, int defencePercent)
        {
            return damage - (int)((double)damage / 100.00 * (double)defencePercent);
        }
    }
}
