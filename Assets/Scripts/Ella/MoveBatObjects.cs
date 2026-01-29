using UnityEngine;
using UnityEngine.UIElements;

public class MoveBatObjects : MonoBehaviour
{
    [SerializeField] private Vector3 _endPos;
    [SerializeField] private float _speed;

    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update()
    {
        rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, _endPos, _speed * Time.deltaTime);
    }
}
