using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public static float countDown = 60;
    private float roundCountDown ;

    private void FixedUpdate()
    {
        if (!MaskPickup.MinigamingIt)
        {
            countDown -= Time.deltaTime;
            roundCountDown = (int)countDown;
            timerText.text = roundCountDown.ToString();
        }
        else
        {
            timerText.text = "";
        }
    }
}


