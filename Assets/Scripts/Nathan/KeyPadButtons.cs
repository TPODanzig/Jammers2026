using UnityEngine;
using UnityEngine.UI;

public class KeyPadButtons : MonoBehaviour
{
    [SerializeField] KeyPad keyPad;
    [SerializeField] string button;

    public void OnPress()
    {
        keyPad.pasword += button;
        keyPad.buttonsPressed++;
    }
}
