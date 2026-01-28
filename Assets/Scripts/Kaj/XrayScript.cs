using UnityEngine;
using UnityEngine.InputSystem;

public class XrayScript : MonoBehaviour
{
    [SerializeField] InputActionReference XrayAction;
    [SerializeField] Transform DitEneXrayMuurtje;
    public int XrayActiveInt = 0;

    void FixedUpdate()
    {
        CheckForXray();
    }
    public void OnEnable()
    {
        XrayAction.action.performed += XrayActivate;
    }

    private void OnDisable()
    {
        XrayAction.action.performed -= XrayActivate;
    }

    void CheckForXray()
    {
        if (XrayActiveInt > 1)
        {
            XrayActiveInt = 0;
        }
    }

    void XrayActivate(InputAction.CallbackContext ctx)
    {
        if (XrayActiveInt == 0)
        {
            DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = false;
            XrayActiveInt++;
        }
        else if(XrayActiveInt == 1)
        {
            DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = true;
            XrayActiveInt++;
        }
    }
}
