using UnityEngine;
using UnityEngine.UIElements;

public class MoveBatObjects : MonoBehaviour
{
    [SerializeField] private Vector3 _endPos;
    [SerializeField] private float _speed;
    void Update()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(transform.position, _endPos, _speed * Time.deltaTime);
    }
}
