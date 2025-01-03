using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SliderValue", menuName = "Scriptable Objects/SliderValue")]
public class SliderValue : ScriptableObject
{




    bool onoff;
    float m_value;
    Action m_FollowAction;


    public float Value
    {
        get { return m_value; }
    }
    public void SetValue(float value)
    {
        m_value = value;
        m_FollowAction();
    }
    public void AddListener(Action action)
    {
        m_FollowAction += action;
    }
}
