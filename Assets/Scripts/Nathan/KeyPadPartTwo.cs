using UnityEngine;

public class KeyPadPartTwo : MonoBehaviour
{
    public KeyPad keyPad;
    private void Update()
    {
        if (Input.GetKeyDown("0") && keyPad.inRange == true)
        {
            keyPad.pasword += "0";
            keyPad.buttonsPressed++;
        }
        if (Input.GetKeyDown("1") && keyPad.inRange == true)
        {
            keyPad.pasword += "1";
            keyPad.buttonsPressed++;
        }
        if (Input.GetKeyDown("2") && keyPad.inRange == true)
        {
            keyPad.pasword += "2";
            keyPad.buttonsPressed++;
        }
        if (Input.GetKeyDown("3") && keyPad.inRange == true)
        {
            keyPad.pasword += "3";
            keyPad.buttonsPressed++;
        }
        if (Input.GetKeyDown("4") && keyPad.inRange == true)
        {
            keyPad.pasword += "4";
            keyPad.buttonsPressed++;
        }
        if (Input.GetKeyDown("5") && keyPad.inRange == true)
        {
            keyPad.pasword += "5";
            keyPad.buttonsPressed++;
        }
        if (Input.GetKeyDown("6") && keyPad.inRange == true)
        {
            keyPad.pasword += "6";
            keyPad.buttonsPressed++;
        }
        if (Input.GetKeyDown("7") && keyPad.inRange == true)
        {
            keyPad.pasword += "7";
            keyPad.buttonsPressed++;
        }
        if (Input.GetKeyDown("8") && keyPad.inRange == true)
        {
            keyPad.pasword += "8";
            keyPad.buttonsPressed++;
        }
        if (Input.GetKeyDown("9") && keyPad.inRange == true)
        {
            keyPad.pasword += "9";
            keyPad.buttonsPressed++;
        }
    }
}
