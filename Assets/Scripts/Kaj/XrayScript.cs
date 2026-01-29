using UnityEngine;
using UnityEngine.InputSystem;

public class XrayScript : MonoBehaviour
{
    [SerializeField] InputActionReference XrayAction;
    [SerializeField] Transform DitEneXrayMuurtje;
    //public int XrayActiveInt = 0;
    public bool XrayActive = false;

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
}
