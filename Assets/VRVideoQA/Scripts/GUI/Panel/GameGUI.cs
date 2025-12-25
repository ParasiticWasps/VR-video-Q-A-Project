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
        yield return new WaitForSeconds(2.0f);

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
        videoPanel.gameObject.SetActive(!isQaShow);
        QAPanel.gameObject.SetActive(isQaShow);
    }

    #region 选择题答题后处理
    public void NextQuestion()
    {
        currQuestionIndex++;
        if (currQuestionIndex >= qaList[currQAIndex].QuestionList.Count)
        {
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
            NetTheme();
            return;
        }

        currQuestionIndex = 0;
        QAPanel.Setup(qaList[currQAIndex].QuestionList[currQuestionIndex]);
    }

    private void NetTheme()
    {
        OnNextTheme?.Invoke();
    }

    #endregion

    private void QAPanelSelected(bool b)
    {
        StartCoroutine(QAPanelSelectedCoroutine());
    }

    private IEnumerator QAPanelSelectedCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        NextQuestion();
    }
}
