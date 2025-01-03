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
            throw new System.NotImplementedException("�ڷ��� Ȯ�� �ʿ�");
    }
    public void SetDataValue()
    {

    }
}
