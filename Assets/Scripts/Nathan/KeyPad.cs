using TMPro;
using Unity.Collections;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keyCodeText;
    [SerializeField] Door door;
    public int buttonsPressed;
    public string pasword;

    private void FixedUpdate()
    {
        keyCodeText.text = pasword;
    }
}
