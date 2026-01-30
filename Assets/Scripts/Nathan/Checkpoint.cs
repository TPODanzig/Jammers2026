using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public static Checkpoint Instance;
    public Transform checkPointTransform;

    [SerializeField] CharacterController cc;

    

    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject); // Voorkom dubbele instanties
        }
    }
    
    private void Update()
    {
        Debug.Log(checkPointTransform.position);
    }


    public void OnHit()
    {
        cc.enabled = false;
        gameObject.transform.position = checkPointTransform.position;
        gameObject.transform.rotation = checkPointTransform.rotation;
        cc.enabled = true;

        Debug.Log("ste the player back to last checkpoint");
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("CheckPoint"))
    //    {
    //        checkPointTransform = other.gameObject.transform;
    //    }
    //}
}
