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
    }

    private void OnTriggerStay(Collider other)
    { 
        if (InteractAction.IsPressed())
        {
            if (other.CompareTag("Player"))
            {
                MinigamingIt = true;
            }
        }
    }

    void TriggerMinigame()
    {
        if (PlayerMaskManager.SMaskAmount == 0)
        {
            Minigame1.SetActive(true);
        }
        else if (PlayerMaskManager.SMaskAmount == 1)
        {
            Minigame2.SetActive(true);
        }
        else if (PlayerMaskManager.SMaskAmount == 2)
        {
            Minigame3.SetActive(true);
        }
        else
        {
            Minigame1.SetActive(false);
            Minigame2.SetActive(false);
            Minigame3.SetActive(false);
        }
    }


    void CollectMask()
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
