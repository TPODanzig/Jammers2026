using UnityEngine;

public class CanvasSnake : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _moveInput;
    public int FoodAmount = 0;

    private MaskPickup parentScript;
    [SerializeField] GameObject _snakeGame;




   

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
        parentScript = transform.parent.transform.GetComponentInParent<MaskPickup>();
   
    }
    
    void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        _moveInput.y = inputY * _speed * Time.deltaTime;
        _moveInput.x = inputX * _speed * Time.deltaTime;
        transform.Translate(_moveInput);


        if (flippedVAR == Flipped.flipedRight)
        {
            this.gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            this.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (flippedVAR == Flipped.flippedLeft) 
        {
            this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            this.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (inputX < 0)
        {
            flippedVAR = Flipped.flippedLeft;
        }
        else if (inputX > 0)
        {
            flippedVAR = Flipped.flipedRight;
        }else if (inputY < 0)
        {
            flippedVAR = Flipped.flippedDown;
        }
        else if(inputY > 0){
            flippedVAR= Flipped.flippedUp;
        }

        if (FoodAmount >= 5)
        {
            //parentScript.CollectMask();
            //MaskPickup.MinigamingIt = false;
            Destroy(_snakeGame);
        }
    }
}
