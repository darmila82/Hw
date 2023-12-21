using Assets.Scripts.Entity.Skills;

namespace Assets.Scripts.Entity.Characters.Enemy
{
    public class Enemy : Character
    {
        protected int damageMorale = 0;



        // TODO додати систему моралі до Hero
        public void getDamageMorale()
        {
            return;
        }
        public void setDamageMorale(int damageMorale)
        {
            this.damageMorale = damageMorale;
        }

        public void useSkill(TargetPosition targetPosition, int position)
        {
            
            SkillResponse sr = this.skills[position].use(this, targetPosition);
        }

        public override int getFinalDamage()
        {
            return this.damage;
        }
    }
}
