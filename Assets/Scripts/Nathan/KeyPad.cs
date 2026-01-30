using TMPro;
using Unity.Collections;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keyCodeText;
    [SerializeField] Door door;
    public GameObject keyPad;
    public bool inRange = false;
    public int buttonsPressed;
    public string pasword;

    private void FixedUpdate()
    {
        keyCodeText.text = pasword;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keyPad.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keyPad.SetActive(false);
            inRange = false;
        }
    }
}
