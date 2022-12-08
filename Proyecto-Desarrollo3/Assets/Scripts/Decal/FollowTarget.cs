using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float rotateSpeed;

    void LateUpdate()
    {
        if (target)
        {
            transform.position = target.position + offset;
            transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
    public void EnableIndicator()
    {
        gameObject.SetActive(true);
    }
    public void DisableIndicator()
    {
        gameObject.SetActive(false);
    }
}
