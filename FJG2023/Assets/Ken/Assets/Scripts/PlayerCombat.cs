using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 2f;
    float nextAttackTime = 0F;
    float xPlayerDirection;
    float yPlayerDirection;

    Vector3 spawnPos;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        xPlayerDirection = Input.GetAxisRaw("Horizontal");
        yPlayerDirection = Input.GetAxisRaw("Vertical");

        HitBoxPosition();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate; // 0,5sec
        }
    }

    //vaihtaa hitboxin syoton suuntaanw
    void HitBoxPosition()
    {
        if(xPlayerDirection < 0 )
        {
            attackPoint.localPosition = new Vector3(-1, 0, 0);
        } 
        else if(xPlayerDirection > 0) 
        {
            attackPoint.localPosition = new Vector3(1, 0, 0);
        } 
        else if (yPlayerDirection < 0)
        {
            attackPoint.localPosition =  new Vector3(0, -1, 0);
        }
        else if (yPlayerDirection > 0)
        {
            attackPoint.localPosition = new Vector3(0, 1, 0);
        }
    }

    void Attack()
    {

        //play attack animation

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit");
        }

    }

    // Draw the HitBox
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
