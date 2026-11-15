using UnityEngine;
using UnityEngine.InputSystem;

public class MainMovement : MonoBehaviour
{
    InputAction moveAction;
    public Rigidbody2D rb;
    public float speed;
    public Animator animator;
    public SpriteRenderer sr;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = moveValue * speed;
        animator.SetInteger("Vertical", (int)moveValue.y);
        animator.SetBool("Horizontal", moveValue.x == 0 ? false : true);
        if(moveValue.x < 0) sr.flipX = true;
        if (moveValue.x > 0) sr.flipX = false;
    }
}
