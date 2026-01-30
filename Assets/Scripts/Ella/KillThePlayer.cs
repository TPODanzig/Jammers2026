using UnityEngine;

public class KillThePlayer : MonoBehaviour
{
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(CamoMask.Instance.CamoMaskOn == false)
    //    {
    //        Checkpoint.Instance.OnHit();
    //        Debug.Log("Kill the paleyr here");
    //    }
    //    Debug.Log("kill the player test");
        
    //}


    private void OnTriggerStay(Collider other)
    {
        if (CamoMask.Instance.CamoMaskOn == false)
        {
            Checkpoint.Instance.OnHit();
            Debug.Log("Kill the paleyr here");
        }
        Debug.Log("kill the player test");

    }
}
