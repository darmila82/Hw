using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Services.Scene
{
    public class CanvasCreator 
    {
        public static Canvas CreateCanvas(string name, Vector2 vector)
        {
            GameObject canvasObject = new GameObject(name);
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.transform.position = vector;

            return canvas;
        }

        public static RectTransform CreateBlock(string name, Vector2 position, Vector2 size, Color backgroundColor)
        {
            GameObject blockObject = new GameObject(name);
            RectTransform blockRectTransform = blockObject.AddComponent<RectTransform>();
            Image blockImage = blockObject.AddComponent<Image>();

            blockRectTransform.anchoredPosition = position;
            blockRectTransform.sizeDelta = size;

            blockImage.color = backgroundColor;

            return blockRectTransform;
        }

        // Функція для створення текстового поля з заданими параметрами
        public static TextMeshProUGUI CreateText(string name, RectTransform parent, string text, Vector2 anchoredPosition)
        {
            GameObject textObject = new GameObject(name);
            TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();

            textComponent.text = text;
            textComponent.fontSize = 24;
            textComponent.color = Color.white;
            textComponent.alignment = TextAlignmentOptions.Center;
            textRectTransform.sizeDelta = new Vector2(200, 20);

            textRectTransform.SetParent(parent, false);
            textRectTransform.anchoredPosition = anchoredPosition;

            return textComponent;
        }
    }
}
