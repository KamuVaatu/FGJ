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
    private int totalPotatoes = 0;
    private long totalScore = 0;
    bool bagfull = false;
    public TMP_Text currentPotato;
    public TMP_Text currentScore;
    public GameObject gameoverScreen;
    

    [ContextMenu("Increase a score")]
    public void AddPotato() 
    {
        potatoesCarrying++;
        currentPotato.text = "Potatoes: " + potatoesCarrying;
    }

    [ContextMenu("Unload")]
    public void Unload()
    {
        PointsCalculator(potatoesCarrying);
        potatoesCarrying = 0;
        bagfull = false;
        currentPotato.text = "Potatoes: " + potatoesCarrying;
    }

    private void PointsCalculator(int potatoes)
    {
        

        if (potatoes == maxPotatoes)
        {
            totalScore += potatoes * 100;
        } 
        else
        {
            totalScore += potatoes * 10;
        }

        totalPotatoes += potatoes;

        if (totalPotatoes % 150 == 0)
        {
            totalScore *= 2;
        }

        currentScore.text = "Score: " + totalScore;
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
}
