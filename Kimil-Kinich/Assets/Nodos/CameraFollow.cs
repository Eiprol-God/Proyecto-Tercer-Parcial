using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform Target;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Vector3 Offset;
    [SerializeField]
    private float smoothtime;

    private Vector3 velocity= Vector3.zero;

    private void LateUpdate()
    {
        Vector3 targetPosition = Target.position + Offset;
        cameraTransform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity, smoothtime);

        transform.LookAt(Target);
    }

}
