using UnityEngine;

public class XrayScript : MonoBehaviour
{
    [SerializeField] GameObject DitEneXrayMuurtje;
    public bool XrayActive = false;
    public GameObject Volume;
    
    [SerializeField] Material OpagueMat;
    [SerializeField] Material TransMat;

    void FixedUpdate()
    {
        if (DitEneXrayMuurtje != null)
        {
            if (PlayerMaskManager.SWearingMask &&
            PlayerMaskManager.SActiveMask == PlayerMaskManager.ActiveMask.XRay)
            {
                DitEneXrayMuurtje.gameObject.tag = "Interactable";
            }
            else
            {
                DitEneXrayMuurtje.gameObject.tag = "Untagged";
            }
        }
            XrayActivate();
    }

    public void XrayActivate()
    {
        if (XrayActive)
        {
            //DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = false;

            Volume.SetActive(true);

            if (DitEneXrayMuurtje != null)
            {
                DitEneXrayMuurtje.GetComponent<Renderer>().material = TransMat;
            }
        }
        else if(!XrayActive)
        {
            //DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = true;
            Volume.SetActive(false);

            if (DitEneXrayMuurtje != null)
            {
                DitEneXrayMuurtje.GetComponent<Renderer>().material = OpagueMat;
            }
        }
    }
}
