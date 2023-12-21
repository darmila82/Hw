using Assets.Scripts.Entity.Characters;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Services
{
    enum LabelName
    {
        Name = 0,
        Class = 1,
        CurrentHp = 2,
        MaxHp = 4
    }

    class FillingSprite
    {
        public void fillSprite(GameObject sprite, Character character)
        {

            Text[] texts = sprite.GetComponentsInChildren<Text>();

            texts[(int)LabelName.Name].text = character.getName();
            texts[(int)LabelName.Class].text = character.getClassName();
            texts[(int)LabelName.CurrentHp].text = character.getHealthPoint().ToString();
            texts[(int)LabelName.MaxHp].text = character.getHealthPointMax().ToString();    
        }

        public void updateSkills(Character targetCharacter)
        {
            List<GameObject> list = GameObject.FindGameObjectsWithTag("SkillButton").ToList<GameObject>();
        }
    }
}
