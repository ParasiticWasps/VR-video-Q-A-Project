using Pico.Platform;
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
        //videoPlayer.Play();
        videoPlayer.Pause();
    }

    /// <summary>
    /// 播放视频
    /// </summary>
    /// <param name="callback"></param>
    public void PlayVideo(Action callback)
    {
        videoPlayer?.Play();
        StartCoroutine(WaitPlayFinishCoroutine(callback));
    }

    private IEnumerator WaitPlayFinishCoroutine(Action callback)
    {
        yield return new WaitUntil(() => 
        {
            int currTime = (int)videoPlayer.time;
            int lengthTime = (int)videoPlayer.length;
            Debug.Log($"{currTime} / {lengthTime}");
            return currTime == lengthTime || currTime + 1 == lengthTime;
        });

        yield return new WaitForSeconds(2.0f);

        videoPlayer.clip = null;
        callback?.Invoke();
    }

    /// <summary>
    /// 停止播放视频
    /// </summary>
    public void Stop()
    {
        videoPlayer?.Stop();
    }
}
