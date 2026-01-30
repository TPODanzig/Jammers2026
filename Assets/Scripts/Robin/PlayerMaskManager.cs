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

    private BlackLighteffect activeBlacklightScript;
    private CamoMask activeDisguiseScript;
    private XrayScript activeXRayScript;

    //audio bs
    [SerializeField] GameObject aPlayer;
    private GameObject ActiveAPlayer;
    private AudioPlayer ActiveAPlayerComp;

    [SerializeField] Image MaskIcon1;
    [SerializeField] Image MaskIcon2;
    [SerializeField] Image MaskIcon3;

    private void Start()
    {
        activeBlacklightScript = GetComponent<BlackLighteffect>();
        activeDisguiseScript = GetComponent<CamoMask>();
        activeXRayScript = GetComponent<XrayScript>();

        SWearingMask = false;
        SActiveMask = ActiveMask.None;
        SMaskAmount = 0;
    }

    private void Update()
    {
        RunDebug();
        RunMasks();
        RunIcons();

        //check of je 1,2,3 of L mouse klikt
        if (Input.GetKey("1") && SMaskAmount >= 1 && SActiveMask != ActiveMask.BlackLight)
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
        else if (Input.GetKey("2") && SMaskAmount >= 2 && SActiveMask != ActiveMask.Disguise)
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
        else if (Input.GetKey("3") && SMaskAmount >= 3 && SActiveMask != ActiveMask.XRay)
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

        else if (Input.GetKey(KeyCode.G) && SActiveMask != ActiveMask.None)
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

            if (ActiveAPlayer == null)
            {
                //Speel audio
                ActiveAPlayer = Instantiate(aPlayer);
                ActiveAPlayerComp = ActiveAPlayer.GetComponent<AudioPlayer>();
                ActiveAPlayerComp.AudioPlayerResource = AudioPlayer.AudioResource.EquipMask;
            }

            //Timer klaar, selecteer je actie
            if (activeWearTimer > 1)
            {
                if (Input.GetKey("1"))
                {
                    SActiveMask = ActiveMask.BlackLight;
                }
                else if (Input.GetKey("2"))
                {
                    SActiveMask = ActiveMask.Disguise;
                }
                else if (Input.GetKey("3"))
                {
                    SActiveMask = ActiveMask.XRay;
                }
                else if (Input.GetKey(KeyCode.G))
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
            Destroy(ActiveAPlayer);
        }
        else if (activeWearTimer > 0 && !inputActive) //als je vroegtijdig loslaat, loopt de timer snel leeg
        {
            WearTimer.value = activeWearTimer;
            activeWearTimer -= Time.deltaTime * 2;
            Destroy(ActiveAPlayer);
        }
        else if (activeWearTimer <= 0 && !inputActive) //rest mode hier
        {
            WearTimer.gameObject.SetActive(false);
            activeWearTimer = 0;
            maskLocked = false;
            Destroy(ActiveAPlayer);
        }
    }

    void RunMasks()
    {
        if (SWearingMask)
        {
            if (SActiveMask == ActiveMask.BlackLight)
            {
                activeBlacklightScript.BLMaskActive = true;
                activeDisguiseScript.CamoMaskOn = false;
                activeXRayScript.XrayActive = false;
            }
            else if (SActiveMask == ActiveMask.Disguise)
            {
                activeBlacklightScript.BLMaskActive = false;
                activeDisguiseScript.CamoMaskOn = true;
                activeXRayScript.XrayActive = false;
            }
            else if (SActiveMask == ActiveMask.XRay)
            {
                activeBlacklightScript.BLMaskActive = false;
                activeDisguiseScript.CamoMaskOn = false;
                activeXRayScript.XrayActive = true;
            }
        }
        else
        {
            activeBlacklightScript.BLMaskActive = false;
            activeDisguiseScript.CamoMaskOn = false;
            activeXRayScript.XrayActive = false;
        }
    }

    void RunIcons()
    {
        if (SMaskAmount >= 3)
        {
            MaskIcon3.gameObject.SetActive(true);
            MaskIcon2.gameObject.SetActive(true);
            MaskIcon1.gameObject.SetActive(true);
        }
        if (SMaskAmount < 3)
        {
            MaskIcon3.gameObject.SetActive(false);

            MaskIcon2.gameObject.SetActive(true);
            MaskIcon1.gameObject.SetActive(true);
        }
        if (SMaskAmount < 2)
        {
            MaskIcon3.gameObject.SetActive(false);
            MaskIcon2.gameObject.SetActive(false);

            MaskIcon1.gameObject.SetActive(true);
        }
        if (SMaskAmount < 1)
        {
            MaskIcon3.gameObject.SetActive(false);
            MaskIcon2.gameObject.SetActive(false);
            MaskIcon1.gameObject.SetActive(false);
        }

        if (SActiveMask == ActiveMask.None)
        {
            MaskIcon1.color = Color.black;
            MaskIcon2.color = Color.black;
            MaskIcon3.color = Color.black;
        }
        else if (SActiveMask == ActiveMask.BlackLight)
        {
            MaskIcon1.color = Color.white;
            MaskIcon2.color = Color.black;
            MaskIcon3.color = Color.black;
        }
        else if (SActiveMask == ActiveMask.Disguise)
        {
            MaskIcon1.color = Color.black;
            MaskIcon2.color = Color.white;
            MaskIcon3.color = Color.black;
        }
        else if (SActiveMask == ActiveMask.XRay)
        {
            MaskIcon1.color = Color.black;
            MaskIcon2.color = Color.black;
            MaskIcon3.color = Color.white;
        }
    }

    void RunDebug()
    {
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                SMaskAmount++;
            }
        }
    }
}