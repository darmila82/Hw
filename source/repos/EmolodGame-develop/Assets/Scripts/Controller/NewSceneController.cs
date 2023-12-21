using Assets.Scripts.CustomCanvas;
using Assets.Scripts.Entity.Characters.Hero;
using Assets.Scripts.Entity.Characters.Hero.Type;
using Assets.Scripts.Services.Scene;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewSceneController : MonoBehaviour
{
    public TMP_FontAsset customFont;
    public GameObject prefabToInstantiate;
    public List<Hero> heroes = new List<Hero>();
    public List<HeroCanvas> canvas = new List<HeroCanvas>();

    void Start()
    {
        GameObject game = GameObject.FindGameObjectWithTag("HeroWrapper");
        GameObject gameObject = Resources.Load<GameObject>("MiniatureArmy/Prefab/Knight");

        heroes.Add(new Crusader());
        heroes.Add(new Soldier());
        heroes.Add(new Warlock());
        heroes.Add(new PlagueDoctor());

        int coordX = 300;

        foreach (Hero hero in heroes)
        {
            HeroCanvas my = createCharacter(hero.getName(), hero.getClassName(), hero.getPrefabName(), game, new Vector2(coordX, 200));
            coordX -= 200;

            canvas.Add(my);
        }

        Animator anim = canvas[0].getPrefabInstance().GetComponent<Animator>();
        anim.Play("attack");
    }

    private HeroCanvas createCharacter(string name, string cl, string prefabName, GameObject parent, Vector2 position)
    {
        HeroCanvas myCanvas = new HeroCanvas(name, position);

        // Встановлення шрифту для текстових полів
        myCanvas.SetTextAndFont(name, cl, customFont);

        // Встановлення префабу
        myCanvas.SetPrefab(prefabName);
        myCanvas.SetParent(parent.transform);

        return myCanvas;
    }
}
