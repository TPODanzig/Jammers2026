using UnityEngine;

public class KillThePlayer : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(CamoMask.Instance.CamoMaskOn == false)
        {
            Debug.Log("Kill the paleyr here");
        }
        
    }
}
