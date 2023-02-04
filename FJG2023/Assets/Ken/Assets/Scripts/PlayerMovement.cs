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

        animator.SetFloat("Horizontal", xForce);
        animator.SetFloat("Vertical", yForce);

        moveForce = new Vector2(xForce, yForce).normalized;

        animator.SetFloat("Speed", moveForce.sqrMagnitude);
        Debug.Log(moveForce.sqrMagnitude);
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

    private void Flip()
    {
        if (isFacingRight && xForce < 0f || !isFacingRight && xForce > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        } else if ((isFacingUp && yForce < 0f || !isFacingUp && yForce > 0f))
        {
            isFacingUp = !isFacingUp;
            Vector3 localScale = transform.localScale;
            localScale.y *= -1f;
            transform.localScale = localScale;
        }
    }


    //void KnockBack()
    //{
    //    moveForce += forceToApply;
    //    forceToApply /= forceDamping;
    //    if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
    //    {
    //        forceToApply = Vector2.zero;
    //    }
    //    rb.velocity = moveForce;
    //}


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Bullet"))
    //    {
    //        forceToApply += new Vector2(, 0);
    //        Destroy(collision.gameObject);
    //    }
    //}

}
