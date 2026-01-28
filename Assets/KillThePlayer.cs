using UnityEngine;

public class KillThePlayer : MonoBehaviour
{
    [SerializeField] public bool Masked = false;
    private void OnTriggerEnter(Collider other)
    {
        if(Masked == false)
        {
            Debug.Log("Kill the paleyr here");
        }
        
    }
}
