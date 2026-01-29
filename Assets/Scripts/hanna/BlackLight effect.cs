using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BlackLighteffect : MonoBehaviour
{
    bool light;
    public  GameObject Light;
    private void Start()
    {
        if (Light.CompareTag("Light")) {  light = true; }

    }
}
