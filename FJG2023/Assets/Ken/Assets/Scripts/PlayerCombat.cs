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
    public LayerMask neutralObjectLayers;
    public AudioClip attackClip;
    public AudioClip interactClip;
    public AudioSource playeraudio;


    public float attackRate = 2f;
    float nextAttackTime = 0F;
    float xPlayerDirection;
    float yPlayerDirection;

    Vector3 spawnPos;


    void Start()
    {
        playeraudio = gameObject.GetComponent<AudioSource>();
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

        playeraudio.PlayOneShot(attackClip, 1f);
        animator.SetFloat("AttackPosX", attackPoint.localPosition.x);
        animator.SetFloat("AttackPosY", attackPoint.localPosition.y);

        animator.SetTrigger("Attack");


        //play attack animation


        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit");
        }

    }


    // Keraa perunat
    public void interact()
    {
        //sound effect
        playeraudio.PlayOneShot(interactClip, 1f);
        Collider2D[] someObjects= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, neutralObjectLayers);
        foreach (Collider2D someObject in someObjects)
        {
            if (someObject.CompareTag("Potato"))
            {
                //sound effect
                someObject.GetComponent<GoodPotato>().PickUp();
            }

            if (someObject.CompareTag("Keeper"))
            {
                //sound effect
                someObject.GetComponent<InventoryBox>().ReceivePotatoes();
            }
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
