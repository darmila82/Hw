using Assets.Scripts.Services.Builders;

namespace Assets.Scripts.Entity.Characters.Hero.Type
{
    public class Crusader : Tank
    {
        public Crusader() : base() 
        {
            SkillBuilder skillBuilder = new SkillBuilder();
            BuffBuilder buffBuilder = new BuffBuilder();
            // TODO додати бафи на себе, на ціль, массу
            // TODO додати інтерфейс до скіла

            this.prefabName = "Knight";

             
            this.addedSkill(
                skillBuilder
                .initSingleSkill("Удар по щам", Skills.SkillType.Attack)
                .setPercentPower()
                .makeActive()
                .getResult()
                );

            this.addedSkill(
                skillBuilder
                .initSingleSkill("Усилялка", Skills.SkillType.Buff)
                .makeActive()
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
