using UnityEngine;
using UnityEngine.UI;

public class SpriteMatchGame : MonoBehaviour
{
    public Image targetImage; // de sprite die bovenaan staat
    public Sprite[] sprites; // alle mogelijke sprites
    private Sprite currentTarget;
    public GameObject test;
    public Sprite[] ItemSprites;  
    public Image[] targetSprites;
    public RectTransform canvasRect;
    public GameObject itemPrefab;
    void Start()
    {
        SetRandomTarget();
        ItemSetRandomTarget();
        SpawnItems();
    }
    void SetRandomTarget()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        currentTarget = sprites[randomIndex];
        targetImage.sprite = currentTarget;
    }
    void ItemSetRandomTarget()
    {
        Random.Range(targetSprites.Length, ItemSprites.Length);
        
    }

    public Sprite[] itemSprites;

    public int spawnCount = 5;



    void SpawnItems()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject item = Instantiate(itemPrefab, canvasRect);

            Image img = item.GetComponent<Image>();
            img.sprite = itemSprites[Random.Range(0, itemSprites.Length)];

            RectTransform itemRect = item.GetComponent<RectTransform>();
            itemRect.anchoredPosition = GetRandomPosition(itemRect);
        }
    }

    Vector2 GetRandomPosition(RectTransform item)
    {
        float x = Random.Range(
            -canvasRect.rect.width / 2 + item.rect.width / 2,
             canvasRect.rect.width / 2 - item.rect.width / 2
        );

        float y = Random.Range(
            -canvasRect.rect.height / 2 + item.rect.height / 2,
             canvasRect.rect.height / 2 - item.rect.height / 2
        );

        return new Vector2(x, y);
    }
    public int score = 0;

  


}


