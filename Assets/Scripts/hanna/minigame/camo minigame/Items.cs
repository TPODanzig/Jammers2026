using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public Transform spawnTransform;
    private void Start()
    {
        Instantiate(manager.manger.Colors[manager.manger.selectedcolor], spawnTransform);
    }
}
