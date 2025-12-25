using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartGameGUI : MonoBehaviour
{
    public Button StartButton;

    public Action OnClickedStart;

    private void Start()
    {
        StartButton.onClick.AddListener(() => { OnClickedStart?.Invoke(); });
    }
}
