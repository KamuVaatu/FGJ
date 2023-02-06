using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoEnemy : MonoBehaviour
{
    int maxHealth = 150;
    int currentHealth;
    string potato;
    int[] perunaLista = { 6, 7, 8, 9, 10, 11};
    SpriteRenderer colorShift;
    public AudioClip hurt1;
    public AudioClip hurt2;
    public AudioClip hurt3;
    public AudioSource enemyAudio;
    public LogicManager logic;

    



    //public Sprite[] damagestatukset = new Sprite[18]; 

    // Start is called before the first frame update
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
        colorShift = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        //potato = gameObject.GetComponent<SpriteRenderer>().sprite.ToString();
    }

    //int detectPotatoSprite()
    //{

    //    if (potato == "Potatoes_6 (UnityEngine.Sprite)")
    //    {
    //        return perunaLista[0];
    //    }
    //    else if (potato == "Potatoes_7 (UnityEngine.Sprite)")
    //    {
    //        return perunaLista[1];
    //    }
    //    else if (potato == "Potatoes_8 (UnityEngine.Sprite)")
    //    {

    //        return perunaLista[2];
    //    }
    //    else if (potato == "Potatoes_9 (UnityEngine.Sprite)")
    //    {
    //        return perunaLista[3];
    //    }
    //    else if (potato == "Potatoes_10 (UnityEngine.Sprite)")
    //    {
    //        return perunaLista[4];
    //    }
    //    else
    //    {
    //        return perunaLista[5];
    //    }
    //}
    
    //void changeSprite(int damage, int index)
    //{

    //}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // damagestate

        if(currentHealth == 100)
        {
            enemyAudio.PlayOneShot(hurt1, 1f);
            colorShift.color = Color.yellow;
        }

        if (currentHealth == 50)
        {
            enemyAudio.PlayOneShot(hurt2, 1f);
            colorShift.color = Color.red;
        }

        if (currentHealth <= 0)
        {
            enemyAudio.PlayOneShot(hurt3, 1f);
            Die();
        }
    }

    public void PickUp()
    {
        if (logic.IsBagFull() == true)
        {
            return;
        }

        logic.AddPotato();

        //somekinda animation here.

        Destroy(gameObject);
    }

    void Die()
    {
        // tahan kuolema animaatio
        Destroy(gameObject);
    }
}

