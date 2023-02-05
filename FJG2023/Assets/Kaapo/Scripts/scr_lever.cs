using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_lever : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] newSprite;
    private float distance;
    public bool leverPulled;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(leverPulled);
        GameObject[] tentacles = GameObject.FindGameObjectsWithTag("tag_tentacle"); //gather all levers in room to this array
        foreach (GameObject tentacle in tentacles) //check every lever for distance
        {
            for(int i = 31; i > 0; i--)
            {
                distance = Vector3.Distance(tentacle.GetComponent<scr_tentacle>().vertexPositions[i], gameObject.transform.position);
                if(distance < 2f)
                {
                    spriteRenderer.sprite = newSprite[1];
                    leverPulled = true;
                    StopCoroutine(reArm()); //wait until really released
                    StartCoroutine(reArm());
                }
            }
        }
    }

    IEnumerator reArm()
    {
        yield return new WaitForSeconds(5); //wait till release
        spriteRenderer.sprite = newSprite[0];
        leverPulled = false;
    }
}
