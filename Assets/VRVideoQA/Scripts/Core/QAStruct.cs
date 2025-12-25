using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[Serializable]
public class SceneStruct
{
    public List<QAStruct> qaList;
}

[Serializable]
public class QAStruct
{
    public VideoClip clip;

    public List<QuestionStruct> QuestionList = new List<QuestionStruct>();
}

[Serializable]
public class QuestionStruct
{
    public string question;
    public List<ChoiceStruct> choices = new List<ChoiceStruct>();
    public string answer;
}

[Serializable]
public class ChoiceStruct
{
    public string choice;
    public bool isAnswer;
}