using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class InteractionScript : MonoBehaviour
{
    public GameObject InteractionText;
    private Door door;

    //audio bs
    [SerializeField] GameObject aPlayer;
    private GameObject ActiveAPlayer;
    private AudioPlayer ActiveAPlayerComp;

    [SerializeField] GameObject vaultDeur;

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
                //Speel audio
                ActiveAPlayer = Instantiate(aPlayer);
                ActiveAPlayerComp = ActiveAPlayer.GetComponent<AudioPlayer>();
                ActiveAPlayerComp.AudioPlayerResource = AudioPlayer.AudioResource.Interact;


                if (other.GetComponent<Door>() != null)
                {
                    other.GetComponent<Door>().OpenDoor();
                }
                else if (other.GetComponent<MaskPickup>() != null)
                {
                    other.GetComponent<MaskPickup>().PlayerInteraction();
                }
                else if (other.gameObject == vaultDeur)
                {
                    Debug.Log("Game win");
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

    private void FixedUpdate()
    {
        InteractionText.SetActive(false);
    }
}
