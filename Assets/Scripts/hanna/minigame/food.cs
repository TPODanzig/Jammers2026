using UnityEngine;

public class food : MonoBehaviour
{
    public BoxCollider2D grid;
    [SerializeField] private CanvasSnake CanvasSnakeScript;
    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        Bounds bounds = this.grid.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position= new Vector3(Mathf.Round(x),Mathf.Round(y),this.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        CanvasSnakeScript.FoodAmount++;
        RandomizePosition();
        
    }
}
