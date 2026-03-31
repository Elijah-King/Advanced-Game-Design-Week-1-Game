using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform targetTransform;

    [Header("Camera Offset")]
    public Vector2 manualOffset = Vector2.zero;
    private Vector3 offset;

    [Header("Camera Limits")]
    public bool cameraLimitsEnabled = false;
    public float cameraMinX, cameraMaxX;
    public float cameraMinY, cameraMaxY;

    void Start()
    {
        // Correct offset: X, Y, and keep camera Z
        offset = new Vector3(manualOffset.x, manualOffset.y, transform.position.z);
    }

    void LateUpdate()
    {
        if (targetTransform == null)
            return;

        // Follow player
        Vector3 newPos = targetTransform.position + offset;

        // Apply limits if enabled
        if (cameraLimitsEnabled)
        {
            newPos.x = Mathf.Clamp(newPos.x, cameraMinX, cameraMaxX);
            newPos.y = Mathf.Clamp(newPos.y, cameraMinY, cameraMaxY);
        }

        transform.position = newPos;
    }
}



