using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private KeyPad keypad;
    [SerializeField] private Vector3 doorRotation;
    [SerializeField] private float openTimer = 0.6f;
    public bool unlockDoor = false;
    private void FixedUpdate()
    {
        if (keypad != null)
        {
            if (PaswordManager.paswordManager.password == keypad.pasword)
            {
                unlockDoor = true;
                keypad.pasword = null;
            }
            else if (keypad.buttonsPressed > 3)
            {
                keypad.buttonsPressed = 0;
                keypad.pasword = null;
            }
            if (unlockDoor == true)
            {
                OpenDoor();
                unlockDoor = false;
            }
        }
    }

    public void OpenDoor()
    {
            transform.Rotate(doorRotation * 4);
    }
}

