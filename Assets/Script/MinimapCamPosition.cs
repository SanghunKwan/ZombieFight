using UnityEngine;

public class MinimapCamPosition : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 camOffset;
    private void Update()
    {
        transform.position = playerTransform.position + camOffset;
    }
}
