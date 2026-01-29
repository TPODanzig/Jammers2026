using UnityEngine;
using UnityEngine.UIElements;

public class MoveBatObjects : MonoBehaviour
{
    [SerializeField] private Vector3 _endPos;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 current;
    void Update()
    {
        current = transform.position;
        this.gameObject.transform.position = Vector3.MoveTowards(current, _endPos, _speed * Time.deltaTime);
    }
}
