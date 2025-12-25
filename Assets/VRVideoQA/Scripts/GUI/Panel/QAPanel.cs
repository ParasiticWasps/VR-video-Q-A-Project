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

    public QuestionStruct currPkg;

    public Action<bool> OnChoiceSelected;

    public void Setup(QuestionStruct pkg)
    {
        currPkg = pkg;

        // Setup question.
        QuestionText.text = currPkg.question;

        // Setup choices.
        OnChoiceSelected += ChoiceSelected;
        for (int i = 0; i < Choices.Count; i++)
        {
            if (i < currPkg.choices.Count)
            {
                Choices[i].Setup(currPkg.choices[i].choice, currPkg.choices[i].isAnswer, OnChoiceSelected);
            }
        }

        // Setup answer.
        AnswerText.text = currPkg.answer;
        AnswerText.gameObject.SetActive(false);
    }

    private void ChoiceSelected(bool a)
    {
        AnswerText.gameObject.SetActive(true);
        // StartCoroutine(ChoiceSelectedCoroutine());
    }

    private IEnumerator ChoiceSelectedCoroutine()
    {
        yield return new WaitForSeconds(3.0f);

    }
}
