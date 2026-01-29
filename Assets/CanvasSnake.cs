using UnityEngine;

public class CanvasSnake : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _moveInput;
    public int FoodAmount;

    private MaskPickup parentScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        parentScript = transform.parent.transform.GetComponentInParent<MaskPickup>();
   
    }
    
    void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        _moveInput.y = inputY * _speed * Time.deltaTime;
        _moveInput.x = inputX * _speed * Time.deltaTime;
        transform.Translate(_moveInput);

        if (FoodAmount >= 5)
        {
            parentScript.CollectMask();
            MaskPickup.MinigamingIt = false;
            Destroy(this.gameObject);
        }
    }
}
