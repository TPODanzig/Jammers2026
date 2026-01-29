using UnityEngine;

public class XrayScript : MonoBehaviour
{
    [SerializeField] GameObject DitEneXrayMuurtje;
    public bool XrayActive = false;
    public GameObject Volume;

    private Material[] Mat;

    void FixedUpdate()
    {
        if (DitEneXrayMuurtje != null)
        {
            if (Mat == null)
            {
                Mat = DitEneXrayMuurtje.GetComponent<Renderer>().materials;
            }

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
                foreach (Material mat in Mat)
                {
                    mat.color = new Color(mat.color.r, mat.color.g, mat.color.g, 0.8f);
                }
            }
        }
        else if(!XrayActive)
        {
            //DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = true;
            Volume.SetActive(false);

            if (DitEneXrayMuurtje != null)
            {
                foreach (Material mat in Mat)
                {
                    mat.color = new Color(mat.color.r, mat.color.g, mat.color.g, 1);
                }
            }
        }

        DitEneXrayMuurtje.GetComponent<Renderer>().materials = Mat;
    }
}
