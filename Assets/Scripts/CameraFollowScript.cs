using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    /* Reused script from Q6 project - LF */

    public Transform targetTransform;

    [Header("Camera Offset")]
    public Vector2 manualOffset = Vector2.zero;
    Vector3 offset;

    public float cameraMaxHeight, cameraMinHeight;
    public float cameraMinX, cameraMaxX;
    public bool cameraLimitsEnabled = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset =  new Vector3(manualOffset.x, manualOffset.x, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetTransform.position + offset;

        // If camera limits enabled, ensure camera is within bounds
        if(cameraLimitsEnabled )
        {
            // Adjust vertical position
            if (transform.position.y > cameraMaxHeight)
                transform.position = new Vector3(transform.position.x, cameraMaxHeight, transform.position.z);
            else if (transform.position.y < cameraMinHeight)
                transform.position = new Vector3(transform.position.x, cameraMinHeight, transform.position.z);

            // Adjust horizontal position
            if (transform.position.x < cameraMinX)
            {
                transform.position = new Vector3(cameraMinX, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > cameraMaxX)
            {
                transform.position = new Vector3(cameraMaxX, transform.position.y, transform.position.z);
            }
        }

    }
}


