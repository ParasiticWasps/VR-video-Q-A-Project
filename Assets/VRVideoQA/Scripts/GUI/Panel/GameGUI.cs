using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameGUI : MonoBehaviour
{
    public VideoClip clip;

    public List<QAStruct> qaList = new List<QAStruct>();

    public GameObject VideoPanel;

    public QAPanel QAPanel;

    public void Setup(VideoClip _clip, List<QAStruct> _list)
    {
        clip = _clip;
        qaList = _list;
    }
}
