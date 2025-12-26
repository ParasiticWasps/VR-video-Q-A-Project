using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimit : MonoBehaviour
{
    public enum limits
    {
        noLimit = 0,
        limit30 = 30,
        limit60 = 60,
        limit80 = 80
    }

    public limits frameRateLimit = limits.noLimit;

    private void Awake()
    {
        Application.targetFrameRate = (int)frameRateLimit;
    }
}
