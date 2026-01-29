using UnityEngine;

public class Pet : MonoBehaviour
{
    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 0.4f)
        {
            transform.position += Vector3.down * Time.deltaTime / 6;
        }
        else if (timer >= 0.4f)
        {
            transform.position += Vector3.up * Time.deltaTime / 6;
        }
        if (timer >= 0.8f)
        {
            timer = 0;
        }
    }
}
