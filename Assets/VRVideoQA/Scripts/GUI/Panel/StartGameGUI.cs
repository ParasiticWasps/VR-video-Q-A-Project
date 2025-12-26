using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartGameGUI : MonoBehaviour
{
    public Button StartButton;

    public GameObject ItemPrefab;

    public Transform prefabParent;

    public Action<int> OnClickedStart;

    private int selectIndex = 0;

    private List<ThemeButton> themeButtons = new List<ThemeButton>();

    public void Setup()
    {
        themeButtons.Clear();
        for (int i = 0; i < VideoQACore.Instance.themeList.Count; i++)
        {
            ThemeStruct theme = VideoQACore.Instance.themeList[i];
            ThemeButton button = Instantiate(ItemPrefab, prefabParent).GetComponent<ThemeButton>();
            button.Setup(theme.themeName, theme.themeImage, i);
            button.OnClickButton += OnThemeButtonClick;
            themeButtons.Add(button);
        }
    }

    private void OnThemeButtonClick(int themeIndex)
    {
        selectIndex = themeIndex;
        for (int i = 0; i < themeButtons.Count; i++)
        {
            Color color = Color.white;
            color = i != selectIndex ? Color.yellow : Color.red;

            ThemeButton button = themeButtons[i];
            button.ButtonClickStyle(color);
        }
    }

    private void Start()
    {
        StartButton.onClick.AddListener(() => { OnClickedStart?.Invoke(selectIndex); });
    }
}
