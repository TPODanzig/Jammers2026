using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public static float countDown = 60;
    private float roundCountDown ;

    private void Start()
    {
        countDown = 600;
    }

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

        if (countDown <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
    }
}


