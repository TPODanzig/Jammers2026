using UnityEngine;

public class XrayScript : MonoBehaviour
{
    [SerializeField] GameObject DitEneXrayMuurtje;
    [SerializeField] GameObject DitEneVaultDeurtje;
    public bool XrayActive = false;
    public GameObject Volume;

    private Material[] Mat;
    private Material[] VaultMat;

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


        if (DitEneVaultDeurtje != null)
        {
            if (VaultMat == null)
            {
                VaultMat = DitEneVaultDeurtje.GetComponent<Renderer>().materials;
            }
            if (PlayerMaskManager.SWearingMask &&
            PlayerMaskManager.SActiveMask == PlayerMaskManager.ActiveMask.XRay)
            {
                DitEneVaultDeurtje.gameObject.tag = "Interactable";
            }
            else
            {
                DitEneVaultDeurtje.gameObject.tag = "Untagged";
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
                    mat.color = new Color(mat.color.r, mat.color.g, mat.color.g, 0.3f);
                }
            }

            if (DitEneVaultDeurtje != null)
            {
                foreach (Material mat in VaultMat)
                {
                    mat.color = new Color(mat.color.r, mat.color.g, mat.color.g, 0.1f);
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
            if (DitEneVaultDeurtje != null)
            {
                foreach (Material mat in VaultMat)
                {
                    mat.color = new Color(mat.color.r, mat.color.g, mat.color.g, 1);
                }
            }
        }

        if (DitEneXrayMuurtje != null)
        {
            DitEneXrayMuurtje.GetComponent<Renderer>().materials = Mat;
            DitEneVaultDeurtje.GetComponent<Renderer>().materials = VaultMat;
        }
    }
}
