using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float playerSpeed = 1;
    public float jumpHeight = 1;

    private float horizontalDirection;
    private float verticalDirection;
    private Rigidbody2D rb;

    private bool jumpClick = false;
    private bool ground = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(horizontalDirection, verticalDirection, 0) * Time.deltaTime * playerSpeed; 
        if (Input.GetButtonDown("Jump") && ground)
        {
            jumpClick = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalDirection * playerSpeed, rb.velocity.y);

        if (jumpClick)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumpClick = false;
            ground = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Box"))
        {
            ground = true;
        }
    }
}