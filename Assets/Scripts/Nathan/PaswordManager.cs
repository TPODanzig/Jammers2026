using UnityEngine;

public class PaswordManager : MonoBehaviour
{
    public static PaswordManager paswordManager;
    public string password;

    private void Awake()
    {
        paswordManager = this;
    }
}
