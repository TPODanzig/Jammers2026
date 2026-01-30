using UnityEngine;

public class Togglelore : MonoBehaviour
{
    public int counter = 0;
    public GameObject text;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }

}

