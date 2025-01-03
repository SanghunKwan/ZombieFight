using SGA.UI;
using UnityEngine;

[RequireComponent(typeof(InteractionWithScriptableObject))]
public class BackupScriptableObject : MonoBehaviour
{
    [SerializeField] SliderNToggle backupObject;
    [SerializeField] ComplexWindow complexWindow;

    InteractionWithScriptableObject interactComponent;

    private void Awake()
    {
        interactComponent = GetComponent<InteractionWithScriptableObject>();
        interactComponent.backupAction += GetData;
        complexWindow.dataReroll += OverlapData;

    }

    public void GetData()
    {
        backupObject.CopyValue(interactComponent.SliderNToggleObject);
    }
    public void OverlapData()
    {
        interactComponent.SliderNToggleObject.CopyValue(backupObject);
    }
}
