using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private KeyPad keypad;
    [SerializeField] private Vector3 doorRotation;
    [SerializeField] private float openTimer = 0.6f;
    public bool unlockDoor = false;
    private void FixedUpdate()
    {
        if (PaswordManager.paswordManager.password == keypad.pasword)
        {
            unlockDoor = true;
        }
        else if (keypad.buttonsPressed > 3)
        {
            keypad.buttonsPressed = 0;
            keypad.pasword = null;
        }
        if (unlockDoor == true)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        openTimer -= Time.deltaTime;
        if (openTimer >= 0.2f)
        {
            transform.Rotate(doorRotation * Time.deltaTime);
        }
    }
}

