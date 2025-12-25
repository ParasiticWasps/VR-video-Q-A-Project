using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoiceItem : MonoBehaviour
{
    public Toggle selected;
    
    public TextMeshProUGUI choiceText;

    public TextMeshProUGUI hint; // 对或者错图标

    public bool isAwser;

    public void Setup(string _text, bool _isAwser, Action<bool> toggleEvent)
    {
        selected.onValueChanged.AddListener((value) =>
        {
            if (isAwser)
            {
                VideoQACore.Instance.Correct += 1;
            }
            else
            {
                VideoQACore.Instance.Incorrect += 1;
            }

            toggleEvent?.Invoke(value);
        });

        hint.gameObject.SetActive(false);
        choiceText.text = _text;
        selected.isOn = false;
    }

    private void ShowHintText(string _hint)
    {
        hint.gameObject.SetActive(true);
        hint.text = _hint;
        hint.color = isAwser ? Color.green : Color.red;
    }
}
