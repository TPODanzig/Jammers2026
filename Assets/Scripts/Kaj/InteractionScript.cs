using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void FixedUpdate()
    {
            if (MaskPickup.MinigamingIt)
        {
            InteractionText.SetActive(false);
        }
        dabidoo();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            InteractionText.SetActive(true);
            if (Input.GetKeyDown("e"))
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
                    SceneManager.LoadScene("Win Scene");
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

    void dabidoo()
    {
        InteractionText.SetActive(false);
    }
}
