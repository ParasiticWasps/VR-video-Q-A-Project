using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThemeButton : MonoBehaviour
{
    private TextMeshProUGUI titleText;

    private Button Button;

    public Image themeImage;

    public Image BorderImage;

    public int themeIndex;

    public Action<int> OnClickButton;

    private void Awake()
    {
        Button = GetComponent<Button>();
        titleText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        Button.onClick.AddListener(() => { OnClickButton?.Invoke(themeIndex); });
    }

    public void Setup(string title, Sprite img, int _themeIndex)
    {
        themeIndex = _themeIndex;
        titleText.text = title;
        themeImage.sprite = img;
    }

    public void ButtonClickStyle(Color color)
    {
        BorderImage.color = color;
    }
}
