using Assets.Scripts.Entity.Skills;
using System;

namespace Assets.Scripts.Services.Skills
{
    public interface ISkillStrategy
    {
        SkillResponse execute(Skill skill);
    }
}
