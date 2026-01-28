using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BlackLighteffect : MonoBehaviour
{
    public  GameObject Volume;
   public InputActionReference blacklight;
    public Image Fill;

    private void Update()
    {
        if (blacklight != null) 
        {
            Fill.fillAmount = blacklight.action.GetTimeoutCompletionPercentage();
        }
    }

    private void OnEnable()
    {
        blacklight.action.performed += MaskActive;

    }
    private void OnDisable()
    {
        blacklight.action.performed -= MaskActive;

    }
    void MaskActive(InputAction.CallbackContext ctx) 
    {
        
        Volume.SetActive(true);
    } 
}
