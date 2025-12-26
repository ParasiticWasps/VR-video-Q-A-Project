using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QAPanel : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;

    public List<ChoiceItem> Choices = new List<ChoiceItem>();

    public TextMeshProUGUI AnswerText;

    public TextMeshProUGUI delayText;

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
                Choices[i].OnIncorrectSelected += ChoiceSelected;
                Choices[i].OnIncorrectSelected += OnChoiceSelected;
                Choices[i].Setup(currPkg.choices[i].choice, currPkg.choices[i].isAnswer);
            }
        }

        // Setup answer.
        AnswerText.text = currPkg.answer;
        AnswerText.gameObject.SetActive(false);
    }

    private void ChoiceSelected()
    {
        delayText.gameObject.SetActive(true);
        AnswerText.gameObject.SetActive(true);
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        while(delaySeconds >= 0)
        {
            delayText.text = $"{delaySeconds}";
            delaySeconds -= 1;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
