using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;


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
    public GameObject segmentPrefab;

    [SerializeField] Canvas c;
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
        }
        else if (Input.GetKeyDown(KeyCode.S))
        { 
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        { 
            _direction = Vector2.right;

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
            Transform segment = Instantiate(segmentPrefab.transform, c.transform);
            segment.transform.position = _segments[_segments.Count - 1].position;
            
            _segments.Add(segment);
            
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }

        if(collision.tag == "Wall")
        {
            Debug.Log("you hit a wall");
            rect.anchoredPosition = new Vector2(0f, 0f);
        }
    }
}
