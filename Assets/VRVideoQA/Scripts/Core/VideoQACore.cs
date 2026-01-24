using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责游戏逻辑部分
/// </summary>
public class VideoQACore : MonoBehaviour
{
    public static VideoQACore Instance;

    public List<ThemeStruct> themeList = new List<ThemeStruct>();

    public ThemeStruct CurrTheme { get => themeList[ThemeIndex]; }

    public int ThemeIndex = 0;

    public int Correct = 0;

    public int Incorrect = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
