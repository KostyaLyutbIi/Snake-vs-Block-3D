using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Snake;

    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - Snake.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(0, Snake.position.y + offset.y, Snake.position.z + offset.z);
    }
}