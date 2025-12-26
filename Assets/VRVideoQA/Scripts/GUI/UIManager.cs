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
        EndPanel.OnBackEvent += BackSelectPanel;

        StartPanel.Setup();
    }

    private void StartGame(int themeIndex)
    {
        StartPanel.gameObject.SetActive(false);
        QAPanel.gameObject.SetActive(true);
        QAPanel.Show(VideoQACore.Instance.themeList[themeIndex].qaList);
    }

    private void LearnFinished()
    {
        EndPanel.gameObject.SetActive(true);
        EndPanel.Setup();

        QAPanel.gameObject.SetActive(false);
    }

    private void BackSelectPanel()
    {
        EndPanel.gameObject.SetActive(false);
        StartPanel.gameObject.SetActive(true);
    }
}