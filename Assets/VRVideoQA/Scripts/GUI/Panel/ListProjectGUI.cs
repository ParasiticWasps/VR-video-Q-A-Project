using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListProjectGUI : MonoBehaviour
{
    // public List<ThemeButton> buttonList = new List<ThemeButton>();

    public GameObject ItemPrefab;

    public Transform prefabParent;

    public Action<int> OnEnterTheme;

    public void Setup()
    {
        for (int i = 0; i < VideoQACore.Instance.themeList.Count; i++)
        {
            ThemeStruct theme = VideoQACore.Instance.themeList[i];
            ThemeButton button = Instantiate(ItemPrefab, prefabParent).GetComponent<ThemeButton>();
            button.Setup(theme.themeName, i);
            button.OnClickButton += OnThemeButtonClick;
        }
    }

    private void OnThemeButtonClick(int themeIndex)
    {
        OnEnterTheme?.Invoke(themeIndex);
    }
}
