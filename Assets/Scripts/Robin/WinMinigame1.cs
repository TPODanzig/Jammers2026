using Unity.VisualScripting;
using UnityEngine;

public class WinMinigame1 : MonoBehaviour
{
    private GameObject parent;
    private MaskPickup parentScript;

    private void Start()
    {
        parentScript = transform.parent.transform.GetComponentInParent<MaskPickup>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        parentScript.CollectMask();
        MaskPickup.MinigamingIt = false;
        Destroy(this.gameObject);
    }
}
