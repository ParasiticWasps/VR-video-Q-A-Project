using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoiceItem : MonoBehaviour
{
    public Toggle selected;
    
    public TextMeshProUGUI choiceText;

    public UnityEvent<bool> onValueChanged;

    public void Setup(string _text)
    {
        selected.onValueChanged.AddListener((value) => onValueChanged.Invoke(value));
        choiceText.text = _text;
    }
}
