using UnityEngine;
using UnityEngine.InputSystem;

public class XrayScript : MonoBehaviour
{
    [SerializeField] InputActionReference XrayAction;
    [SerializeField] Transform DitEneXrayMuurtje;
    public int test = 0;

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
        if (test > 1)
        {
            test = 0;
        }
    }

    void XrayActivate(InputAction.CallbackContext ctx)
    {
        if (test == 0)
        {
            DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = false;
            test++;
        }
        else if(test == 1)
        {
            DitEneXrayMuurtje.GetComponent<MeshRenderer>().enabled = true;
            test++;
        }
    }
}
