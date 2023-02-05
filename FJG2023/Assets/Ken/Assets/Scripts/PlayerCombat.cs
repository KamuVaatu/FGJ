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

    public float attackRate = 2f;
    float nextAttackTime = 0F;
    float xPlayerDirection;
    float yPlayerDirection;

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

        if (Input.GetKeyDown(KeyCode.I))
        {
            interact();
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

        animator.SetFloat("AttackPosX", attackPoint.localPosition.x);
        animator.SetFloat("AttackPosY", attackPoint.localPosition.y);

        animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            // Tagilla voi erottaa viholliset periaatteessa
            if (enemy.GetComponent<PotatoEnemy>())  
            {
                enemy.GetComponent<PotatoEnemy>().TakeDamage(50);
            }
        }
    }

    // Keraa perunat
    public void interact()
    {
        //sound effect

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
