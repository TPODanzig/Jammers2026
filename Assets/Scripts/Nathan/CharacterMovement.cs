using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] float gravity = -9.51f;

    private CharacterController cc;
    private Vector3 velocity;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
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
    }

}
