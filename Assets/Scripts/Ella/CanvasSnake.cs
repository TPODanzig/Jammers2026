using UnityEngine;
using UnityEngine.UI;

public class CanvasSnake : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _moveInput;
    public int FoodAmount = 0;

    private MaskPickup parentScript;
    [SerializeField] GameObject _snakeGame;

    [SerializeField] Sprite sideways;
    [SerializeField] Sprite UpAndDown;

    [SerializeField] Image spriteshit;

    private Vector2 _direction = Vector2.right;
    [SerializeField] RectTransform rect;

    enum Flipped
    {
        flipedRight,
        flippedLeft,
        flippedUp,
        flippedDown
    }
    Flipped flippedVAR = Flipped.flipedRight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        parentScript = transform.parent.transform.parent.transform.GetComponentInParent<MaskPickup>();
    }
    
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.W)) 
        { 
            _direction = Vector2.up;
            flippedVAR = Flipped.flippedUp;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        { 
            _direction = Vector2.down;
            flippedVAR = Flipped.flippedDown;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
            flippedVAR = Flipped.flippedLeft;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        { 
            _direction = Vector2.right;
            flippedVAR = Flipped.flipedRight;

        }


        if (flippedVAR == Flipped.flipedRight)
        {
            spriteshit.sprite = sideways;
            this.gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else if (flippedVAR == Flipped.flippedLeft)
        {
            spriteshit.sprite = sideways;
            this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (flippedVAR == Flipped.flippedUp)
        {
            spriteshit.sprite = UpAndDown;
            this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (flippedVAR == Flipped.flippedDown)
        {
            spriteshit.sprite = UpAndDown;
            this.gameObject.transform.localScale = new Vector3(0.5f, -0.5f, 0.5f);
        }

        

        if (FoodAmount >= 5)
        {
            parentScript.CollectMask();
            MaskPickup.MinigamingIt = false;
            Destroy(_snakeGame);
        }
    }
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y, Mathf.Round(this.transform.position.z));
    }
}
