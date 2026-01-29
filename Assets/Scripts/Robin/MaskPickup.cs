using UnityEngine;
using UnityEngine.InputSystem;

public class MaskPickup : MonoBehaviour
{
    private Vector3 startPos;

    private float spinSpeed;

    private float bounceSpeed;
    private float actualBounceSpeed;
    private float bounceRange;
    private float activeBounce;
    private bool bounceDirection;

    private InputAction InteractAction;

    [SerializeField] GameObject Minigame1;
    [SerializeField] GameObject Minigame2;
    [SerializeField] GameObject Minigame3;

    private GameObject activeMinigame;

    public static bool MinigamingIt;

    private void Start()
    {
        startPos = transform.position;

        spinSpeed = 2.5f;
        bounceSpeed = 2.5f;
        bounceRange = .25f;

        InteractAction = InputSystem.actions.FindAction("Interact");
    }

    private void FixedUpdate()
    {
        Spin();
        Bounce();

        if (MinigamingIt)
        {
            TriggerMinigame();
        }
        else
        {
            Destroy(activeMinigame);
        }
    }

    public void PlayerInteraction()
    { 
        MinigamingIt = true;
    }

    void TriggerMinigame()
    {
        if (PlayerMaskManager.SMaskAmount == 0 && activeMinigame == null)
        {
            activeMinigame = Instantiate(Minigame1, this.transform);
        }
        else if (PlayerMaskManager.SMaskAmount == 1 && activeMinigame == null)
        {
            activeMinigame = Instantiate(Minigame2, this.transform);
        }
        else if (PlayerMaskManager.SMaskAmount == 2 && activeMinigame == null)
        {
            activeMinigame = Instantiate(Minigame3, this.transform);
        }
    }


    public void CollectMask()
    {
        Timer.countDown += 30;
        PlayerMaskManager.SMaskAmount++;
        Destroy(this.gameObject);
    }

    void Spin()
    {
        transform.Rotate(0f, spinSpeed * 10 * Time.deltaTime, 0f);
    }

    void Bounce()
    {
        if (bounceDirection) // up
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + actualBounceSpeed * Time.deltaTime,
                transform.position.z);
        }
        else // down
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - actualBounceSpeed * Time.deltaTime,
                transform.position.z);
        }

        activeBounce = transform.position.y - startPos.y;

        actualBounceSpeed = (bounceRange - activeBounce) * bounceSpeed + bounceSpeed / 100;

        if (activeBounce > bounceRange)
        {
            bounceDirection = false;
        }

        if (activeBounce < -bounceRange)
        {
            bounceDirection = true;
        }
    }
}
