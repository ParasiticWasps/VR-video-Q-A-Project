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

    public int sceneIndex;

    public Action<int> OnClickButton;

    private void Awake()
    {
        Button = GetComponent<Button>();

        titleText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        Button.onClick.AddListener(() => { OnClickButton?.Invoke(sceneIndex); });
    }

    public void Setup(string title, int _sceneIndex)
    {
        sceneIndex = _sceneIndex;
        titleText.text = title;
    }
}
