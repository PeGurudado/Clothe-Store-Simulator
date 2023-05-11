using UnityEngine;

public class SmoothCamera : MonoBehaviour 
{
    [SerializeField] Transform target;
    [SerializeField] float smoothTime = 0.3f;
    Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        //Smoothly move the camera towards the target
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}