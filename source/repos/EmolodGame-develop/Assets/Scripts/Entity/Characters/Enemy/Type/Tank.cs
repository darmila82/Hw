using Assets.Scripts.Services.Builders;
using System;

namespace Assets.Scripts.Entity.Characters.Enemy.Type
{
    internal class Tank : Enemy
    {
        public Tank(int level)
        {
            this.setupParams(
                name: "Enemy Bob",
                healthPoint: 50,
                dodge: 3,
                defencePercent: 25,
                initiative: 14,
                accuracy: 7,
                criticalChance: 15,
                damage: 8);

            SkillBuilder skillBuilder = new SkillBuilder();
            BuffBuilder buffBuilder = new BuffBuilder();

            // TODO TRELLO додати стейт Stun і додати його в білдер 
            this.addedSkill(
                skillBuilder
                .initSingleSkill("Сильний удар", Skills.SkillType.Attack)
                .setPercentPower()
                .setPriority(50)
                .makeActive()
                .getResult()
            );

            this.addedSkill(
                skillBuilder
                .initSingleSkill("Масовий удар", Skills.SkillType.MassAttack)
                .setPercentPower(50)
                .setPriority(30)
                .makeActive()
                .getResult()
            );

            this.addedSkill(
               skillBuilder
                .initSingleSkill("Усилялка", Skills.SkillType.Buff)
                .makeActive()
                .setPriority(20)
                .addBuff(
                    buffBuilder
                    .createBuff("Усилялка", 3)
                    .addDefencePercent(30)
                    .getResult())
                .getResult()
           );
        }
    }
}
