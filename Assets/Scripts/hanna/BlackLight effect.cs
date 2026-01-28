using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BlackLighteffect : MonoBehaviour
{
    public  GameObject Volume;
   public InputActionReference blacklight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MaskActive(InputAction.CallbackContext ctx) 
    {
        Volume.SetActive(true);
    } 
}
