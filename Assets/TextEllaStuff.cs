using UnityEngine;

public class TextEllaStuff : MonoBehaviour
{
    [SerializeField] GenerateText gt;
    private void Start()
    {
        gt.StartLetters();
    }
}
