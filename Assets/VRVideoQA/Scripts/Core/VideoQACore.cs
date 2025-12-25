using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责游戏逻辑部分
/// </summary>
public class VideoQACore : MonoBehaviour
{

    public static VideoQACore Instance;

    public List<SceneStruct> sceneList = new List<SceneStruct>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
