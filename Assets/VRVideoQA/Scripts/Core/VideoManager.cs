using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager instance;

    public VideoPlayer videoPlayer;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LoadClip(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Play();
        videoPlayer.Pause();
    }

    /// <summary>
    /// ≤•∑≈ ”∆µ
    /// </summary>
    /// <param name="callback"></param>
    public void PlayVideo(Action callback)
    {
        videoPlayer?.Play();
        StartCoroutine(WaitPlayFinishCoroutine(callback));
    }

    private IEnumerator WaitPlayFinishCoroutine(Action callback)
    {
        yield return new WaitUntil(() => videoPlayer.isPlaying == false);

        yield return new WaitForSeconds(3.0f);

        callback?.Invoke();
    }
}
