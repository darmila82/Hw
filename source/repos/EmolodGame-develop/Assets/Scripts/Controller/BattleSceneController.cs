using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using Assets.Scripts.Services.Scene;
using Unity.VisualScripting;
using TMPro;

public class BattleSceneController : MonoBehaviour
{
    public List<GameObject> heroes;
    public List<GameObject> enemies;
    public List<Character> playerParty;
    public GameObject canvasWithHealthBarPrefab;
    public TMP_FontAsset comicSans;

    void Start()
    {
        playerParty = (new PartyGenerator()).GeneratePlayerParty();

        FillingSprite sprite = new FillingSprite();

        this.heroes = GameObject.FindGameObjectsWithTag("Hero").ToList<GameObject>();
       
        for (int i = 0; i < heroes.Count; i++)
        {
            sprite.fillSprite(this.heroes[i], playerParty[i]);
        }

        GameObject myCanvasObject = new GameObject("MyCanvasObject");
        


        // Встановлення імені та імені класу
        /*myCanvas.SetFont(comicSans);
        myCanvas.SetName("Player1");
        myCanvas.SetClassName("Warrior");

        // Змінення значення HealthBar
        myCanvas.SetHealth(50); // Поточне здоров'я - 50 з 100

        // Поміщення об'єкта в центр сцени
        myCanvasObject.transform.position = Vector3.zero;
        */
        return;
    }

    void Update()
    {
        
    }
}
