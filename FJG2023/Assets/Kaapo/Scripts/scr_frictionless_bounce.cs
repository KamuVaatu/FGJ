using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class scr_frictionless_bounce : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity= rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);

        rb.velocity = direction * math.max(speed, 0f);
    }
}
