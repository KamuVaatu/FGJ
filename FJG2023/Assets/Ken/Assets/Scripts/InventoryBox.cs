using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBox : MonoBehaviour
{
    LogicManager logic;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    public void ReceivePotatoes()
    {
        if (logic.DoesPlayerCarryPotatoes())
        {
           audioSource.PlayOneShot(audioSource.clip, 0.6f);
        }
        
        logic.Unload();
    }
}
