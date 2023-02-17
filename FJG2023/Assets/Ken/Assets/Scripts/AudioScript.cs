using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip[] damageClips;
    public AudioClip[] punchClips;
    public AudioClip itemClip;
    public AudioClip depositClip;
    public AudioClip bagfullClip;

    public AudioClip SetEnemyClip()
    {
        return damageClips[Random.Range(0,11)];
    }

    public AudioClip SetPunchEffect()
    {
        return punchClips[Random.Range(0,5)];
    }

    public AudioClip ItemPickUp()
    {
        return itemClip;
    }

    public AudioClip ItemDeposit() 
    { 
        return depositClip;
    }

    public AudioClip BagFull() 
    {
        return bagfullClip;
    }
}
