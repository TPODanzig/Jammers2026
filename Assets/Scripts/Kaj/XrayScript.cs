using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class XrayScript : MonoBehaviour
{
    [SerializeField] Transform DitEneXrayMuurtje;
    //public int XrayActiveInt = 0;
    public bool XrayActive = false;
    public GameObject Volume;
    public bool XRayMaskActive;

    private void Update()
    {
        if (XRayMaskActive)
        {
            Run();
        }
        else
        {
            NoRun();
        }
    }

    void FixedUpdate()
    {
        //CheckForXray();
        XrayActivate();
    }
    public void OnEnable()
    {
        //XrayAction.action.performed += XrayActivate;
    }

    private void OnDisable()
    {
        //XrayAction.action.performed -= XrayActivate;
    }

    void CheckForXray()
    {
        //if (XrayActiveInt > 1)
        //{
        //    XrayActiveInt = 0;
        //}
    }

    public void XrayActivate()
    {
        
        if (XrayActive)
        {
            
            DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = false;
        }
        else if(!XrayActive)
        {
            
            DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void Run()
    {
        Volume.SetActive(true);
       
    }
    private void NoRun()
    {
        Volume.SetActive(false);
        
    }
}
