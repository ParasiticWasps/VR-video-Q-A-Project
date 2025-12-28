using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QAPanel : MonoBehaviour
{
    public Text QuestionText;

    public List<ChoiceItem> Choices = new List<ChoiceItem>();

    public TextMeshProUGUI AnswerText;

    public Text delayText;

    public QuestionStruct currPkg;

    public Action OnChoiceSelected;

    private int delaySeconds = 5; // 界面关闭倒计时

    public void Setup(QuestionStruct pkg)
    {
        currPkg = pkg;
        delayText.gameObject.SetActive(false);

        // Setup question.
        QuestionText.text = currPkg.question;

        // Setup choices.
        for (int i = 0; i < Choices.Count; i++)
        {
            if (i < currPkg.choices.Count)
            {
                Choices[i].OnCorrectSelected += ChoiceSelected;
                Choices[i].OnCorrectSelected += OnChoiceSelected;
                Choices[i].OnIncorrectSelected += ChoiceSelected;
                Choices[i].OnIncorrectSelected += OnIncorrectSelectedEvent;
                Choices[i].OnIncorrectSelected += OnChoiceSelected;
                Choices[i].Setup(currPkg.choices[i].choice, currPkg.choices[i].isAnswer);
            }
        }

        // Setup answer.
        AnswerText.text = currPkg.answer;
        AnswerText.gameObject.SetActive(false);
    }

    private void OnIncorrectSelectedEvent()
    {
        AnswerText.gameObject.SetActive(true);
    }

    private void ChoiceSelected()
    {
        delayText.gameObject.SetActive(true);
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        delaySeconds = 5;
        while (delaySeconds >= 0)
        {
            Debug.Log($"delaySeconds: {delaySeconds}");
            delayText.text = $"{delaySeconds}";
            delaySeconds -= 1;
            yield return new WaitForSeconds(1.0f);
        }

        yield break;
    }

    public bool ClearAllEvent()
    {
        for (int i = 0; i < Choices.Count; i++)
        {
            Debug.Log($"Clear: {i}");
            if (i < currPkg.choices.Count)
            {
                Choices[i].OnCorrectSelected -= ChoiceSelected;
                Choices[i].OnCorrectSelected -= OnChoiceSelected;
                Choices[i].OnIncorrectSelected -= ChoiceSelected;
                Choices[i].OnIncorrectSelected -= OnIncorrectSelectedEvent;
                Choices[i].OnIncorrectSelected -= OnChoiceSelected;
                //Choices[i].Setup(currPkg.choices[i].choice, currPkg.choices[i].isAnswer);
            }
        }
        return true;
    }
}
