using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BlackLighteffect : MonoBehaviour
{
    public bool BLMaskActive;
    public GameObject Volume;
    bool light;
    public GameObject Light;

    private GameObject[] LightObjects;

    private void Start()
    {
        LightObjects = GameObject.FindGameObjectsWithTag("Light");
    }

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
        foreach (GameObject obj in LightObjects)
        {
            obj.SetActive(true);
        }
    }

    private void NoRun()
    {
        Volume.SetActive(false);
        foreach (GameObject obj in LightObjects)
        {
            obj.SetActive(false);
        }
    }
}
