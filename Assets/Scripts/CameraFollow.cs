using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1.8f, -2.5f); 
    public float smoothSpeed = 0.125f;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (target != null)
        {
            // Posicionamiento instantáneo inicial
            transform.position = target.TransformPoint(offset);
            transform.rotation = target.rotation;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.TransformPoint(offset);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothSpeed * 2f);
        }
    }
}