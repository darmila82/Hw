using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Characters.Hero;

namespace Assets.Scripts.Entity.Skills
{
    public interface IUseSkill
    {
        string getName();

        int getPriority();

        bool isActive();

        SkillType getSkillType();

        Skill getSelf();

        SkillResponse use(Character hero, TargetPosition targetPosition);
    }
}
