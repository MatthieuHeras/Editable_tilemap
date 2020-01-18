using UnityEngine;
using System.Collections;

public class scr_Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private float rotation;
    private float angle;
    private bool isFlying = true;

    public PolygonCollider2D hitbox;
    public int ID = 0;
    public float throwForce = 5f;
    public float windForce = 10;

    // Start is called before the first frame update
    private void Start()
    {
        rotation = transform.rotation.z;
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = new Vector2(0.2f, 0);
        rb.AddRelativeForce(new Vector2(throwForce, 0), ForceMode2D.Impulse);   
    }

    private void FixedUpdate()
    {
        //        Debug.Log(transform.InverseTransformDirection(rb.velocity));
        if (isFlying)
        {
            float factor = transform.InverseTransformDirection(rb.velocity).y * transform.InverseTransformDirection(rb.velocity).x/windForce;
            rb.AddForceAtPosition(new Vector2(0, -windForce * Time.deltaTime * factor), new Vector2(-0.2f, 0));
            rb.AddForceAtPosition(new Vector2(0, windForce * Time.deltaTime * factor), Vector2.zero);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walls"))
        {
            rb.isKinematic = true; // Stops the arrow from its movement and freeze it until it's looted or destroyed
            rb.velocity = Vector2.zero;
            rb.freezeRotation = true;
            gameObject.tag = "Loot";
            hitbox.isTrigger = true;
            isFlying = false;

            Destroy(gameObject, 20f); // Destroy it if the player does not loot it in 20s
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Walls"))
        {
            rb.isKinematic = false;
            rb.freezeRotation = false;
            hitbox.isTrigger = false;
            gameObject.tag = "Projectile";
            isFlying = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
            collision.GetComponent<scr_Looter>().loot_item(ID);
            Destroy(gameObject);
        }
    }
}
