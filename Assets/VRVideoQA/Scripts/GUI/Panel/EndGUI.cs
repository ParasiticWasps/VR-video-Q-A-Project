using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGUI : MonoBehaviour
{
    #region UI Components

    public TextMeshProUGUI correctCountText;

    public TextMeshProUGUI incorrectCountText;

    public Button backButton;

    #endregion

    public Action OnBackEvent;

    public void Setup()
    {
        correctCountText.text = $"{VideoQACore.Instance.Correct}";
        incorrectCountText.text = $"{VideoQACore.Instance.Incorrect}"; 
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(() => { OnBackEvent?.Invoke(); });

        StartCoroutine(DelayBackCoroutine());
    }

    private IEnumerator DelayBackCoroutine()
    {
        yield return new WaitForSeconds(3.0f);

        OnBackEvent?.Invoke();
    }
}
