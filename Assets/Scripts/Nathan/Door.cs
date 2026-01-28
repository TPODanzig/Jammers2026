using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 doorRotation;
    [SerializeField] private float openTimer = 0.6f;
    private void FixedUpdate()
    {
        openTimer -= Time.deltaTime;
        if (openTimer >= 0.2f)
        {
            transform.Rotate(doorRotation * Time.deltaTime);
        }
    }
}
