using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public StartGameGUI StartPanel;

    public EndGUI EndPanel;

    public GameGUI QAPanel;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        StartPanel.gameObject.SetActive(true);
        EndPanel.gameObject.SetActive(false);
        QAPanel.gameObject.SetActive(false);

        StartPanel.OnClickedStart += StartGame;
        QAPanel.OnNextTheme += LearnFinished;
        QAPanel.BackSelectEvent += BackSelectPanelFromGameGUI;
        EndPanel.OnBackEvent += BackSelectPanel;

        StartPanel.Setup();
    }

    private void StartGame(int themeIndex)
    {
        VideoQACore.Instance.ThemeIndex = themeIndex;
        StartPanel.gameObject.SetActive(false);
        QAPanel.gameObject.SetActive(true);
        QAPanel.Show(VideoQACore.Instance.themeList[themeIndex].qaList);
    }

    private void LearnFinished()
    {
        bool isLearnFinished = VideoQACore.Instance.ThemeIndex + 1 >= VideoQACore.Instance.themeList.Count;
        Action action = isLearnFinished ? 
            () => { EndPanel.Setup(); } : 
            () => { VideoQACore.Instance.ThemeIndex++; QAPanel.Show(VideoQACore.Instance.CurrTheme.qaList); };
        EndPanel.gameObject.SetActive(isLearnFinished);
        QAPanel.gameObject.SetActive(!isLearnFinished);
        action?.Invoke();
    }

    private void BackSelectPanel()
    {
        EndPanel.gameObject.SetActive(false);
        StartPanel.gameObject.SetActive(true);
    }

    private void BackSelectPanelFromGameGUI()
    {
        QAPanel.gameObject.SetActive(false);
        StartPanel.gameObject.SetActive(true);
    }
}