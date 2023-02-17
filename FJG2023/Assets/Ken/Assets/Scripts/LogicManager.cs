using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LogicManager : MonoBehaviour
{
    private int potatoesCarrying = 0;
    public int maxPotatoes = 15;
    public int totalPotatoes = 0;
    bool bagfull = false;
    public TMP_Text currentPotato;
    public TMP_Text currentTotalP;
    public TMP_Text currentBadPotatoes;
    public int BadPotatoCount;
    int OldPotatoCount;
    Animator animator;
    LevelLoader levelLoader;

    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Door").GetComponent<Animator>();
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    void Update()
    {
        OldPotatoCount = BadPotatoCount;
        BadPotatoCount = GameObject.FindGameObjectsWithTag("Potato").Length - 5;
        if(OldPotatoCount != BadPotatoCount) 
        {
            Debug.Log("do it");
            BadPotatoes();
        }

        GameOver();
    }
    
    void BadPotatoes()
    {
        currentBadPotatoes.text = "Bad Potatoes: " + BadPotatoCount;
    }

    [ContextMenu("Increase a score")]
    public void AddPotato() 
    {
        potatoesCarrying++;
        currentPotato.text = "Potatoes: " + potatoesCarrying;
    }

    [ContextMenu("Unload")]
    public void Unload()
    {
        totalPotatoes += potatoesCarrying;
        potatoesCarrying = 0;
        bagfull = false;
        currentPotato.text = "Potatoes: " + potatoesCarrying;
        currentTotalP.text = "Potatoes in Box: " + totalPotatoes;
    }

    public Boolean IsBagFull()
    {
        if (potatoesCarrying == maxPotatoes)
        {
            bagfull = true;
            currentPotato.text = "The bag is full! ";
        }

        return bagfull;
    }
    public void GameOver()
    {
        if (BadPotatoCount >= 100)
        {
            StartCoroutine(Lose());
        }

        if (totalPotatoes >= 150)
        {
            levelLoader.LoadNextLevel(2);
        }
    }

    public bool DoesPlayerCarryPotatoes()
    {
        if (potatoesCarrying == 0)
        {
            return false;
        } 
        else
        {
            return true;
        }
    }

    IEnumerator Lose()
    {
        animator.SetTrigger("open");
        yield return new WaitForSeconds(1);
        levelLoader.LoadNextLevel(1);
    }
}
