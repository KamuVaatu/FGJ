using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10f;
    public float maxRunSpeed = 5f;
    float xForce, yForce; 
    public bool velocityCapEnabled = true;
    private bool isFacingRight = true;
    private bool isFacingUp = true;

    //Knockback
    public float forceDamping = 1.2F;
    public float knockbackForce = 20; 
    public Vector2 forceToApply;

    public Animator animator;


    Vector2 moveForce;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyInput();

        if (velocityCapEnabled)
        {
            CapVelocity();
        }
    }


    private void FixedUpdate()
    {
        AddMovement();
    }

    //liikkeen tunnistus
    private void ApplyInput()
    {
        xForce = Input.GetAxisRaw("Horizontal");
        yForce = Input.GetAxisRaw("Vertical");

        moveForce = new Vector2(xForce, yForce).normalized;

        animator.SetFloat("Horizontal", xForce);
        animator.SetFloat("Vertical", yForce);
        animator.SetFloat("Speed", moveForce.sqrMagnitude);
    }

    private void AddMovement()
    {
       rb.AddForce(moveForce * moveSpeed, ForceMode2D.Impulse);
    }

    //Liike nopeuden rajoitus vertaamalla nykyinen vauhti ja maximi sallittu nopeus jokaisessa akselissa.
    public void CapVelocity()
    {
        float cappedXVelocity = Mathf.Min(Mathf.Abs(rb.velocity.x), maxRunSpeed) * Mathf.Sign(rb.velocity.x);
        float cappedYVelocity = Mathf.Min(Mathf.Abs(rb.velocity.y), maxRunSpeed) * Mathf.Sign(rb.velocity.y);

        rb.velocity = new Vector3(cappedXVelocity, cappedYVelocity);
    }
}
