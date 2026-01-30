using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (instance != this)
        { 
            Destroy(this.gameObject);
        }            
        
        string activeSceneName = SceneManager.GetActiveScene().name;
        if (Input.GetMouseButton(1) || activeSceneName != "Main")
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerMaskManager.SMaskAmount = 0;
        }
    }
}
