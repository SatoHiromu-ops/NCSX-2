
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed = 3f;

    void Update()
    {
        transform.position += Vector3.right
            * scrollSpeed * Time.deltaTime;
    }
}

