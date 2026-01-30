using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] float gravity = -9.51f;

    private CharacterController cc;
    private Vector3 velocity;

    private bool walking;

    private AudioSource walkAudio;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        walkAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!MaskPickup.MinigamingIt)
        {
            Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            cc.Move(move * speed * Time.deltaTime);
            if (cc.isGrounded && velocity.y < 0)
            {
                velocity.y = -2;
            }
            velocity.y += gravity * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !MaskPickup.MinigamingIt)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        if (walking)
        {
            if (!walkAudio.isPlaying)
            {
                walkAudio.Play();
                walkAudio.pitch = Random.Range(.75f, 1f);
            }
        }
        else
        {
            walkAudio.Stop();
        }
    }

}
