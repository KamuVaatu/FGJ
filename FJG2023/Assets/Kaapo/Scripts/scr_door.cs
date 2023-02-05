using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_door : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Animator animator;
    private int leverOpenCount;
    public int openingOrder; //leave number 0, opens first, 1 the second and so on...
    public bool death; //as requested

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] levers = GameObject.FindGameObjectsWithTag("tag_lever"); //gather all levers in room to this array
        foreach (GameObject lever in levers)
        {
            if (lever.GetComponent<scr_lever>().leverPulled == true)
            {
                leverOpenCount++;
                if (leverOpenCount == openingOrder)
                {
                    //animaatio (avautuu)
                }
                if (leverOpenCount == 2)
                {
                    death = true;
                }
            }

        }
    }
}
