using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_door : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] newSprite;
    private int doorOpenCount;
    private Rigidbody2D potatoRigidBody;
    private Rigidbody2D playerRigidBody;
    private bool keepOpen;
    private float smoothMultiplier;

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
            if (keepOpen == false)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                GameObject[] potatoes = GameObject.FindGameObjectsWithTag("Potato");
                foreach (GameObject potato in potatoes)
                {
                    Debug.Log("ZUCC");
                    Vector3 v3Force = 10f * transform.forward;
                    potatoRigidBody = potato.GetComponent<Rigidbody2D>();
                    potato.GetComponent<Rigidbody2D>().AddForce(v3Force);

                    playerRigidBody = player.GetComponent<Rigidbody2D>();
                    player.transform.position -= new Vector3(0, (1 * smoothMultiplier) * Time.deltaTime, 0);
                    smoothMultiplier += 0.0025f;
                }
            }
        }
    }
}
