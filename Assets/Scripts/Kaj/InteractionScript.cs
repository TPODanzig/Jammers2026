using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    public GameObject InteractionText;

    private void Start()
    {
        InteractionText.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            //Debug.Log("bitch");
            InteractionText.SetActive(true);
            if (Input.GetKey("e"))
            {
                if (other.GetComponent<MaskPickup>() != null)
                {
                    other.GetComponent<MaskPickup>().PlayerInteraction();
                }
                else
                {
                    Destroy(other.gameObject);
                }
                InteractionText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("lasagna");
        InteractionText.SetActive(false);
    }
}
