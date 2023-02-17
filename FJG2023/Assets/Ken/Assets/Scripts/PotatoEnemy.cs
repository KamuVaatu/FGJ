using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PotatoEnemy : MonoBehaviour
{
    int maxHealth = 150;
    int currentHealth;
    string potato;
    SpriteRenderer spriteRenderer;
    Sprite[] damagestate;
    private AudioSource enemyAudio;
    public LogicManager logic;
    private AudioScript audioScript;
    



    //public Sprite[] damagestatukset = new Sprite[18]; 

    // Start is called before the first frame update
    void Start()
    {
        audioScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScript>();
        enemyAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        string potato = spriteRenderer.sprite.ToString();
        currentHealth = maxHealth;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        damagestate = GameObject.FindWithTag("Sprite").GetComponent<SpriteChange>().DetectPotatoSprite(potato);
    }


    

    void changesprite(int damage, int index)
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth == 100)
        {
            enemyAudio.PlayOneShot(audioScript.SetEnemyClip(), 0.5f);
            spriteRenderer.sprite = damagestate[0];
        }

        if (currentHealth == 50)
        {
            enemyAudio.PlayOneShot(audioScript.SetEnemyClip(), 0.5f);
            spriteRenderer.sprite = damagestate[2];
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {

    }

    void test()
    {

    }
}

