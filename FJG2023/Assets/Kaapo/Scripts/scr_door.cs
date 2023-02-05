using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_door : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] newSprite;
    private int doorOpenCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] levers = GameObject.FindGameObjectsWithTag("tag_lever"); //gather all levers in room to this array
        foreach (GameObject lever in levers) //check every lever for distance
        {
            if (lever.GetComponent<scr_lever>().leverPulled == true)
            {
                doorOpenCount++;
            }
        }
        if (doorOpenCount == 0) //all levers are off
        {
            spriteRenderer.sprite = newSprite[0];
        }

        if (doorOpenCount == 1) //i lever on
        {
            spriteRenderer.sprite = newSprite[1];
        }

        if (doorOpenCount == 2) //2 levers on
        {
            spriteRenderer.sprite = newSprite[2];
        }

        if (doorOpenCount > 2) //3 or more levers on
        {
            Destroy(gameObject);
        }
        doorOpenCount = 0; //start again
    }
}
