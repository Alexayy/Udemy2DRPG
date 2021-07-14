using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float moveSpeed;
    public Animator animator;

    void Start()
    {
        
    }

    void Update()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        
        animator.SetFloat("moveX", rigidbody2D.velocity.x);
        animator.SetFloat("moveY", rigidbody2D.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 ||
            Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 ||
            Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
