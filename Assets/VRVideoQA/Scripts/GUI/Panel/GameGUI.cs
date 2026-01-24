using Pico.Platform;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameGUI : MonoBehaviour
{
    public VideoClip clip;

    public List<QAStruct> qaList = new List<QAStruct>();

    public VideoPanel videoPanel;

    public QAPanel QAPanel;

    public int currQAIndex = 0;

    public int currQuestionIndex = 0; // 当前视频的题目

    public Action OnShowPanel;

    public Action OnNextTheme;

    #region Setup

    public void Show(List<QAStruct> _qalist)
    {
        Setup(_qalist);
        // OnShowPanel?.Invoke();
    }

    public void Setup(List<QAStruct> _qalist)
    {
        SwitchPanel(false);

        currQAIndex = 0;
        currQuestionIndex = 0;

        qaList = _qalist;
        clip = _qalist[currQAIndex].clip;

        videoPanel.OnPlayFinished += VideoPlayFinished;
        QAPanel.OnChoiceSelected += QAPanelSelected;

        StartCoroutine(SetupCoroutine());
    }

    private IEnumerator SetupCoroutine()
    {
        videoPanel.LoadClip(clip);

        yield return new WaitForSeconds(0.1f);

        videoPanel.PlayVideo();
    }

    #endregion

    private void VideoPlayFinished()
    {
        QAStruct qa = qaList[currQAIndex];
        QAPanel.Setup(qa.QuestionList[currQuestionIndex]);
        SwitchPanel(true);
    }

    private void SwitchPanel(bool isQaShow)
    {
        QAPanel.gameObject.SetActive(isQaShow);
    }

    #region 选择题答题后处理
    public void NextQuestion()
    {
        Debug.Log("NextQuestion");
        currQuestionIndex++;
        if (currQuestionIndex >= qaList[currQAIndex].QuestionList.Count)
        {
            Debug.Log($"NextQuestion: {currQuestionIndex} / {qaList[currQAIndex].QuestionList.Count}");
            videoPanel.OnPlayFinished -= VideoPlayFinished;
            QAPanel.OnChoiceSelected -= QAPanelSelected;
            QAPanel.ClearAllEvent();
            NextQA();
            return;
        }

        QAPanel.Setup(qaList[currQAIndex].QuestionList[currQuestionIndex]);
    }

    private void NextQA()
    {
        currQAIndex++;
        if (currQAIndex >= qaList.Count)
        {
            NextTheme();
            return;
        }

        currQuestionIndex = 0;
        SwitchPanel(false);
        clip = qaList[currQAIndex].clip;

        videoPanel.OnPlayFinished += VideoPlayFinished;
        QAPanel.OnChoiceSelected += QAPanelSelected;

        StartCoroutine(SetupCoroutine());
        //QAPanel.Setup(qaList[currQAIndex].QuestionList[currQuestionIndex]);
    }

    private void NextTheme()
    {
        Debug.Log("Next Theme");
        currQAIndex = 0;
        currQuestionIndex = 0;
        OnNextTheme?.Invoke();
    }

    #endregion

    private void QAPanelSelected()
    {
        StartCoroutine(QAPanelSelectedCoroutine());
    }

    private IEnumerator QAPanelSelectedCoroutine()
    {
        yield return new WaitForSeconds(5.0f);

        NextQuestion();
    }
}
