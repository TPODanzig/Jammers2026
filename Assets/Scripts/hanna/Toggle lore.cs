using UnityEngine;

public class Togglelore : MonoBehaviour
{
    public int counter = 0;
    public GameObject text;

    private void FixedUpdate()
    {
        if (counter > 1)
        {
            counter = 0;
        }
    }
    public void kurkboard() 
    {
        if (counter == 0)
        {
            text.SetActive(true);
            counter++;
        }
        else if (counter == 1)
        {
            text.SetActive(false);
            counter++;
        }
    }
}

