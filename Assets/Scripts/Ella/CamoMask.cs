using UnityEngine;

public class CamoMask : MonoBehaviour
{
    public static CamoMask Instance;

    public bool CamoMaskOn = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject); // Voorkom dubbele instanties
        }
    }

}
