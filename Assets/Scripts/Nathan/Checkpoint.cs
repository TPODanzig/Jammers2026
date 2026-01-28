using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform checkPointTransform;

    public void OnHit()
    {
        gameObject.transform.position = checkPointTransform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint"))
        {
            checkPointTransform = other.gameObject.transform;
        }
    }
}
