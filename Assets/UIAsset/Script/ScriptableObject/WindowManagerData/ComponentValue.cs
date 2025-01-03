using UnityEngine;

[CreateAssetMenu(fileName = "ComponentValue", menuName = "Scriptable Objects/ComponentValue")]
public class ComponentValue : ScriptableObject
{
    public float[] floats;
    public int[] ints;
    public bool[] bools;
}
