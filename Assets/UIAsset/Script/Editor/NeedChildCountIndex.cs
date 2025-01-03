using SGA.UI;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SGA.UI.InteractionWithScriptableObject))]
public class NeedChildCountIndex : Editor
{
    SerializedProperty toggleNum;
    SerializedProperty sliderNum;


    private void OnEnable()
    {
        toggleNum = serializedObject.FindProperty("toggleUsingNum");
        sliderNum = serializedObject.FindProperty("sliderUsingNum");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        toggleNum.intValue = (int)(UsedChildNumber)EditorGUILayout.EnumFlagsField("ActiveToggleChildIndex", (UsedChildNumber)toggleNum.intValue);
        sliderNum.intValue = (int)(UsedChildNumber)EditorGUILayout.EnumFlagsField("ActiveSliderChildIndex", (UsedChildNumber)sliderNum.intValue);

        serializedObject.ApplyModifiedProperties();
    }

}
