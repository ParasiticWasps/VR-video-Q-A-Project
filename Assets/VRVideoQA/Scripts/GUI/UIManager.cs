using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public StartGameGUI StartPanel;

    public EndGUI EndPanel;

    public GameGUI QAPanel;

    public ListProjectGUI ListPanel;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        StartPanel.gameObject.SetActive(true);
        EndPanel.gameObject.SetActive(false);
        QAPanel.gameObject.SetActive(false);
        ListPanel.gameObject.SetActive(false);

        StartPanel.OnClickedStart += StartGame;
        ListPanel.OnEnterTheme += EnterGameGUI;
    }

    public void StartGame()
    {
        StartPanel.gameObject.SetActive(false);
        ListPanel.gameObject.SetActive(true);
        ListPanel.Setup();
    }

    private void EnterGameGUI(int themeIndex)
    {
        QAPanel.Show(VideoQACore.Instance.themeList[themeIndex].qaList);
        ListPanel.gameObject.SetActive(false);
    }
}
