using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class CanvasSnake : MonoBehaviour
{
    
    private Vector2 _moveInput;
    public int FoodAmount = 0;

    private MaskPickup parentScript;
    [SerializeField] GameObject _snakeGame;

    [SerializeField] Sprite sideways;
    [SerializeField] Sprite UpAndDown;

    [SerializeField] Image spriteshit;

    private Vector2 _direction = Vector2.right;
    [SerializeField] RectTransform rect;

    
    List<Transform> _segments = new List<Transform>();

    [SerializeField] private float gridSize = 32f;
    public Transform segmentPrefab;

    [SerializeField] Canvas c;

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
        parentScript = transform.parent.transform.parent.transform.GetComponentInParent<MaskPickup>();

        _segments.Add(this.transform);

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

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        Vector2 pos = rect.anchoredPosition;
        pos += _direction * gridSize;
        rect.anchoredPosition = pos;

    }

    private void Grow()
    {
        for ( int i = 0; i <6; i++)
        {
            Transform segment = Instantiate(segmentPrefab, c.transform);
            segment.position = _segments[_segments.Count - 1].position;
            _segments.Add(segment);
        }
        //Transform segment = Instantiate(segmentPrefab, c.transform);
        //segment.position = _segments[_segments.Count - 1].position;
        //_segments.Add(segment);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }
    }
}
