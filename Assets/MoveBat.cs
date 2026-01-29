using UnityEngine;

public class MoveBat : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Vertical");
        _moveInput.y = input * _speed * Time.deltaTime;
        transform.Translate(_moveInput);
    }
}
