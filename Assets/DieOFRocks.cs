using UnityEngine;

public class DieOFRocks : MonoBehaviour
{
    //put the objects back where they were
    [SerializeField] private GameObject TheseObejcts;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(TheseObejcts);
    }
}
