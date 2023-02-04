using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoEnemy : MonoBehaviour
{
    public int maxHealth = 150;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("hit");

        // iskun vastaanotto animaatio tanne

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // tahan kuolema animaatio
        Destroy(gameObject);
    }
}

