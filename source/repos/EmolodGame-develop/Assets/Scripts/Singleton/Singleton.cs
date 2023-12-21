using System;
using System.Collections.Generic;
using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Characters.Enemy;
using Assets.Scripts.Entity.Characters.Hero;
using Assets.Scripts.Entity.Skills;

namespace Assets.Scripts
{
    public class Singleton
    {
        protected int money = 0;

        private static Singleton instance;
        private Random random = null;

        private List<Character> heroParty = new List<Character>();
        private List<Character> enemyParty = new List<Character>();

        private Singleton()
        {
            this.random = new Random();
        }

        public Character getHero(TargetPosition index)
        {
            if (heroParty.Count == 0 || heroParty.Count < (int)index)
            {
                throw new Exception("Empty array");
            }

            return heroParty[(int)index];
        }

        public Character getEnemy(TargetPosition index)
        {
            if (enemyParty.Count == 0 || enemyParty.Count < (int)index)
            {
                throw new Exception("Empty array");
            }

            return enemyParty[(int)index];
        }

        public int getRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);   
        }

        public int getMoney()
        {
            return money;
        }
        public void setMoney(int money)
        {
            this.money = money;
        }

        public void IncreaseMoney(int amount)
        {
            money += amount;
        }

        public void DecreaseMoney(int value)
        {
            if (money >= value)
            {
                money -= value;
            }
            else
            {
                Console.WriteLine("Not enough money!");
            }
        }

        public static Singleton getInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
        //set() and get() for enemy and hero list
        public List<Character> getHeroParty() 
        {
            return heroParty;
        }
        public void setHeroParty(List<Character> heroParty)
        {
            this.heroParty = heroParty;
        }
        public List<Character> getEnemyParty()
        {
            return enemyParty;
        }
        public void setEnemyParty(List<Character> enemyParty)
        {
            this.enemyParty = enemyParty;
        }
    }
}
