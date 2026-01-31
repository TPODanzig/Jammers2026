using UnityEngine;



public class Togglelore : MonoBehaviour
{
    public int counter = 0;
    public GameObject text;
    public float timer;

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (counter > 1)

            if (counter > 1)
            {
                counter = 0;
            }
    }
    public void kurkboard()
    {
        if (counter == 0 && timer <= 0)
        {
            text.SetActive(true);
            counter++;
        }
        else if (counter == 1 && timer <= 0)
        {
            text.SetActive(false);
            counter++;
        }
    }
}

 

