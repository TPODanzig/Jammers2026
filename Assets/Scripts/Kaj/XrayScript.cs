using UnityEngine;

public class XrayScript : MonoBehaviour
{
    [SerializeField] Transform DitEneXrayMuurtje;
    public bool XrayActive = false;
    public GameObject Volume;

    void FixedUpdate()
    {
        XrayActivate();
    }

    public void XrayActivate()
    {
        
        if (XrayActive)
        {
            
            DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = false;
            Volume.SetActive(true);
        }
        else if(!XrayActive)
        {
            DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = true;
            Volume.SetActive(false);
        }
    }
}
