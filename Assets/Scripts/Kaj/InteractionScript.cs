using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    public GameObject InteractionText;
    private Door door;

    private void Start()
    {
        InteractionText.SetActive(false);
    }

    private void Update()
    {
            if (MaskPickup.MinigamingIt)
        {
            InteractionText.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            InteractionText.SetActive(true);
            if (Input.GetKey("e"))
            {
                if (other.GetComponent<Door>() != null)
                {
                    other.GetComponent<Door>().OpenDoor();
                }
                if (other.GetComponent<MaskPickup>() != null)
                {
                    other.GetComponent<MaskPickup>().PlayerInteraction();
                }
                else if (PlayerMaskManager.SWearingMask && 
                PlayerMaskManager.SActiveMask == PlayerMaskManager.ActiveMask.XRay)
                {
                    Destroy(other.gameObject);
                }
                InteractionText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractionText.SetActive(false);
    }
}
