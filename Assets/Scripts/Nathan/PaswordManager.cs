using TMPro;
using UnityEngine;

public class PaswordManager : MonoBehaviour
{
    public static PaswordManager paswordManager;
    public string password;
    [SerializeField] private string[] digits;

    [SerializeField] TMP_Text PasswordText;

    private void Awake()
    {
        paswordManager = this;
    }
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            password += Random.Range(0, digits.Length);
        }
        Debug.Log(password);

        PasswordText.text = password;
    }
}
