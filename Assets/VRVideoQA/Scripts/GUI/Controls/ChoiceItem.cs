using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.UI.Toggle;

public class ChoiceItem : MonoBehaviour
{
    public Button selectedButton;
    
    public TextMeshProUGUI choiceText;

    public Sprite correctImage; // 正确图标

    public Sprite incorrectImage; // 错误图标

    public Image hintImage;

    public Action OnIncorrectSelected; // 选择错误选项时触发的事件

    public bool isAwser;

    public void Setup(string _text, bool _isAwser)
    {
        isAwser = _isAwser;
        selectedButton.onClick.RemoveAllListeners();

        hintImage.gameObject.SetActive(false);
        choiceText.text = _text;

        selectedButton.onClick.AddListener(() =>
        {
            if (isAwser)
            {
                VideoQACore.Instance.Correct += 1;
            }
            else
            {
                VideoQACore.Instance.Incorrect += 1;
                OnIncorrectSelected?.Invoke();
            }
            ShowHintImage();
        });
    }

    private void ShowHintImage()
    {
        hintImage.gameObject.SetActive(true);
        hintImage.sprite = isAwser ? correctImage : incorrectImage;
    }
}
