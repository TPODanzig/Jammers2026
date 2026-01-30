using UnityEngine;

public class CamoMask : MonoBehaviour
{
    public static CamoMask Instance;

    public GameObject Volume;

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

    private void Update()
    {
        if(CamoMaskOn == true)
        {
            Volume.SetActive(true);
        }
        else
        {
            Volume.SetActive(false);
        }
    }

}
