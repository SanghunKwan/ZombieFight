using UnityEngine;

[CreateAssetMenu(fileName = "WindowData", menuName = "Scriptable Objects/WindowData")]
public class WindowData : ScriptableObject
{
    float m_value;

    public void SetValue(float value)
    {
        m_value = value;
    }
}
