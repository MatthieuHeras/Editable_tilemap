using UnityEngine;

public class scr_PlayerControls : MonoBehaviour
{
    // Variables that can be modified in the inspector
    public float directionalForce = 200;
    public float jumpForce = 25;
    public bool airControl = false;

    // Components of the object (get in the start function)
    private Rigidbody2D rb;
    private Animator anim;

    // Variables inner to the script
    private Vector2 speed = Vector2.zero;

    // Made once at the begining (after Awake)
    private void Start()
    {
        // initialize animator
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Apply an impulsion on the player
    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    // Made every frame as often as possible (more often than FixedUpdate)
    private void Update()
    {
        speed = rb.velocity;
        speed.x /= 10;
        if (speed.x < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        anim.SetFloat("XSpeed", Mathf.Abs(speed.x));
        anim.SetFloat("YSpeed", speed.y);

        // Adjusting the animation depending on the current speed
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("state_Move"))
            anim.speed = Mathf.Abs(speed.x)*2;
        else anim.speed = 1;
    }

    // Made every frame, specialized for physics
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Q))
            rb.AddForce(new Vector2(-directionalForce * Time.deltaTime, 0), ForceMode2D.Force);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(new Vector2(directionalForce * Time.deltaTime, 0), ForceMode2D.Force);
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Jump();
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walls"))
        {
            anim.SetBool("IsFlying", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walls"))
            anim.SetBool("IsFlying", true);
    }

    public void TakeDamage(int damage)
    {
        // take damage
        anim.SetTrigger("Hit");
    }
}