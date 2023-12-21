using System.Collections.Generic;
using System;

namespace Assets.Scripts.Services
{
    public class MonsterNameHelper
    {
        private List<string> monsterName = new List<string>();

        private MonsterNameHelper()
        {
        }

        public string GetRandomMonsterName()
        {
            if (monsterName.Count == 1)
            {
                throw new Exception("MonsterNameList empty");
            }
            else
            {
                return monsterName[Singleton.getInstance().getRandomNumber(0, monsterName.Count)];
            }
        }
    }
}
