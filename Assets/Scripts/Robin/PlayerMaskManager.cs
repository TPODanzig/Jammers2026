using UnityEngine;

public class PlayerMaskManager : MonoBehaviour
{
    public static int SMaskAmount;

    public enum ActiveMask
    {
        None,
        BlackLight,
        Disguise,
        XRay
    }

    public static bool SWearingMask;
    public static ActiveMask SActiveMask;

    private void Update()
    {
        if (Input.GetKeyDown("1") && SMaskAmount >= 1)
        {
            SActiveMask = ActiveMask.BlackLight;
        }
        if (Input.GetKeyDown("2") && SMaskAmount >= 2)
        {
            SActiveMask = ActiveMask.Disguise;
        }
        if (Input.GetKeyDown("3") && SMaskAmount >= 3)
        {
            SActiveMask = ActiveMask.XRay;
        }
    }
}