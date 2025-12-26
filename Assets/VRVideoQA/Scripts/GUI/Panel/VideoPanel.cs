using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPanel : MonoBehaviour
{
    public Action OnPlayFinished;

    public void LoadClip(VideoClip clip)
    {
        VideoManager.instance.LoadClip(clip);
    }

    // ≤•∑≈ ”∆µ
    public void PlayVideo()
    {
        VideoManager.instance.PlayVideo(OnPlayFinished);
    }
}
