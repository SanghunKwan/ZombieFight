using UnityEngine;

[CreateAssetMenu(fileName = "AudioSourceObject", menuName = "Scriptable Objects/AudioSourceObject")]
public class AudioSourceObject : ScriptableObject
{
    Component component;
    System.Type type;


    public void SetDataType<T>(T savedComponent) where T : Component
    {
        type = typeof(T);
        component = new Component();
    }

    public T GetData<T>() where T : Component
    {
        if (type.Equals(typeof(T)))
            return (T)component;

        else
            throw new System.NotImplementedException("자료형 확인 필요");
    }
    public void SetDataValue()
    {

    }
}
