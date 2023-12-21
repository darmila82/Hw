using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Services.Scene;

namespace Assets.Scripts.CustomCanvas
{
    public class HeroCanvas : MonoBehaviour
    {
        private Canvas canvas;
        private RectTransform textBlock;
        private RectTransform prefabBlock;
        private RectTransform healthBarBlock;
        private TextMeshProUGUI nameText;
        private TextMeshProUGUI classNameText;
        private GameObject prefabInstance;
        private Image healthBar;

        public HeroCanvas(string name, Vector2 vector)
        {
            // Створення об'єкту Canvas
            canvas = CanvasCreator.CreateCanvas(name, vector);

            // Створення блоків
            // Створення блоку для тексту
            textBlock = CanvasCreator.CreateBlock("TextBlock", new Vector2(0, 0), new Vector2(200, 150), Color.clear);
            nameText = CanvasCreator.CreateText("NameText", textBlock, "Name: ", new Vector2(0, 60));
            classNameText = CanvasCreator.CreateText("ClassNameText", textBlock, "ClassName: ", new Vector2(0, 20));

            nameText.fontSize = 28;
            nameText.fontStyle = FontStyles.Bold;
            nameText.color = Color.red;

            // Створення блоку для префабу
            prefabBlock = CanvasCreator.CreateBlock("PrefabBlock", new Vector2(0, -200), new Vector2(200, 400), Color.clear);

            // Створення блоку для HealthBar
            healthBarBlock = CanvasCreator.CreateBlock("HealthBarBlock", new Vector2(0, -400), new Vector2(200, 100), Color.clear);

            // Розміщення блоків в Canvas
            textBlock.SetParent(canvas.transform, false);
            prefabBlock.SetParent(canvas.transform, false);
            healthBarBlock.SetParent(canvas.transform, false);
        }

        // Функція для встановлення тексту та шрифту для текстових полів
        public void SetTextAndFont(string playerName, string className, TMP_FontAsset font)
        {
            nameText.text = playerName;
            classNameText.text = className;

            nameText.font = font;
            classNameText.font = font;
        }

        // Функція для встановлення префабу
        public void SetPrefab(string name)
        {
            // Видалення попереднього префабу, якщо він є
            if (prefabInstance != null)
            {
                Destroy(prefabInstance);
            }

            // Створення нового екземпляру префабу
            prefabInstance = Instantiate(Resources.Load<GameObject>("MiniatureArmy/Prefab/" + name), prefabBlock);
            prefabInstance.transform.localPosition = new Vector2(0, -200);
            //prefabInstance.transform.position = new Vector2(0, 200);
            prefabInstance.transform.localScale = new Vector2(-200, 200);
        }

        public GameObject getPrefabInstance()
        {
            return prefabInstance;
        }

        // Функція для прив'язки Canvas до parent
        public void SetParent(Transform parent)
        {
            canvas.transform.SetParent(parent, false);
        }
    }
}
