using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPanel : MonoBehaviour
{
    public Action OnPlayFinished;

    // ≤•∑≈ ”∆µ
    public void PlayVideo()
    {
        VideoManager.instance.PlayVideo(OnPlayFinished);
    }
}
