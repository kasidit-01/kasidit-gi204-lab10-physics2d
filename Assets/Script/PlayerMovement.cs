using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    float move;
    [SerializeField] float speed;

    [SerializeField] float jumpForse;
    [SerializeField] bool isJumping;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2 (rb2d.linearVelocity.x, jumpForse));
            Debug.Log("Jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
