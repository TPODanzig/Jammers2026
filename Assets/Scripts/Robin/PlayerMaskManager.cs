using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] Slider WearTimer;
    private float activeWearTimer;

    private bool maskLocked;

    private bool inputActive;

    private void Update()
    {
        //check of je 1,2,3 of L mouse klikt

        if (Input.GetKeyDown("1") && SMaskAmount >= 1)
        {
            if (SWearingMask)
            {
                inputActive = true;
            }
            else
            {
                SActiveMask = ActiveMask.BlackLight;
            }
        }
        else if (Input.GetKeyDown("2") && SMaskAmount >= 2)
        {
            if (SWearingMask)
            {
                inputActive = true;
            }
            else
            {
                SActiveMask = ActiveMask.Disguise;
            }
        }
        else if (Input.GetKeyDown("3") && SMaskAmount >= 3)
        {
            if (SWearingMask)
            {
                inputActive = true;
            }
            else
            {
                SActiveMask = ActiveMask.XRay;
            }
        }

        else if (Input.GetKey(KeyCode.Mouse0))
        {
            inputActive = true;
        }

        else //reset mask lock en de imput bool als je niks aanklikt
        {
            inputActive = false;
            maskLocked = false;
        }

        //Als je iets klikt, start de timer

        if (inputActive && !maskLocked)
        {
            WearTimer.gameObject.SetActive(true);
            WearTimer.value = activeWearTimer;
            activeWearTimer += Time.deltaTime;

            //Timer klaar, selecteer je actie
            if (activeWearTimer > 1)
            {
                if (Input.GetKeyDown("1"))
                {
                    SActiveMask = ActiveMask.BlackLight;
                }
                else if (Input.GetKeyDown("2"))
                {
                    SActiveMask = ActiveMask.Disguise;
                }
                else if (Input.GetKeyDown("3"))
                {
                    SActiveMask = ActiveMask.XRay;
                }
                else if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (!SWearingMask)
                    {
                        SWearingMask = true;
                    }
                    else if (SWearingMask)
                    {
                        SWearingMask = false;
                    }
                }

                activeWearTimer = 0;
                maskLocked = true;
                //zet de timer weer op 0 en lock de mask knoppen totdat je ze los laat (om loops te verkomen)
            }
        }

        else if (maskLocked) //laat mask niet zien als het locked is
        {
            WearTimer.gameObject.SetActive(false);
        }
        else if (activeWearTimer > 0 && !inputActive) //als je vroegtijdig loslaat, loopt de timer snel leeg
        {
            WearTimer.value = activeWearTimer;
            activeWearTimer -= Time.deltaTime * 2;
        }
        else if (activeWearTimer <= 0 && !inputActive) //rest mode hier
        {
            WearTimer.gameObject.SetActive(false);
            activeWearTimer = 0;
            maskLocked = false;
        }
    }
}