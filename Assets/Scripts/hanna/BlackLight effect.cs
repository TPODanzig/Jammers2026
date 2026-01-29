using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BlackLighteffect : MonoBehaviour
{
    public bool BLMaskActive;
    public GameObject Volume;
    public InputActionReference blacklight;
    public Image Fill;
    bool light;
    public GameObject Light;

    private void Update()
    {
        if (BLMaskActive)
        {
            Run();
        }
        else
        {
            NoRun();
        }
    }

    private void Run()
    {
        Volume.SetActive(true);
        if (Light.CompareTag("Light")) 
        { 
            light = true;
        }
    }

    private void NoRun()
    {
        Volume.SetActive(false);
        if (Light.CompareTag("Light"))
        {
            light = false;
        }
    }
}
