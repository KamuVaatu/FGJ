using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bad_potato : MonoBehaviour
{
    public float randomX;
    public float randomY;
    private int generateThisMany;
    private int current;
    private bool doOnce;
    private bool detachLock;
    private bool detatched;
    public Material tentacleMaterial;
    public Material shadowMaterial;
    public Rigidbody rigidBody;
    private Vector3 ejectForce;
    public Vector3 attachPoint;
    public SpriteRenderer spriteRenderer;
    public Sprite potatoSprite;
    private int sproutAtRandom;

    // Start is called before the first frame update
    void Start()
    {
        generateThisMany = Random.Range(8, 8); //amount of roots generated
        ejectForce = new Vector3(Random.Range(-1f, 1f),Random.Range(-1f, 1f),0); //force at which the potato will eject from root
        rigidBody.angularDrag = 0f; //remove drag
        rigidBody.useGravity = false; //remove gravity
        spriteRenderer.sprite = potatoSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (detachLock == false)
        {
            StartCoroutine(detach());
            detachLock = true;
        }

        if (detatched == false)
        {
            //transform.position = attachPoint;
        }

        if (doOnce == true) //lock after use
        {
            StartCoroutine(addTentacle()); //enter sprouting sequence
            doOnce = false; //lock
        }
    }

    IEnumerator addTentacle()
    {
        if (current != generateThisMany) //if the limit is not reached yet
        {
            randomX = Random.Range(-1f, 1f); //direction, in which the tentacle will grow
            randomY = Random.Range(-1f, 1f); //direction, in which the tentacle will grow
            sproutAtRandom = Random.Range(10, 20);

            yield return new WaitForSeconds(sproutAtRandom); //wait this long to create new tentacle
            GameObject tentacle = new GameObject("Tentacle"); //make new tentacle
            tentacle.transform.parent = gameObject.transform; //add this object as the parent
            tentacle.tag = "tag_tentacle"; //give tentacle tag to seperate it from shadow objects
            tentacle.AddComponent<scr_tentacle>(); //add script to tentacle
            tentacle.GetComponent<scr_tentacle>().tentacleMaterial = tentacleMaterial; //add material to root
            tentacle.GetComponent<scr_tentacle>().shadowMaterial = shadowMaterial; //also store shadow material for later use

            tentacle.GetComponent<scr_tentacle>().potatoSprite = potatoSprite; //also store this sprite to root

            GameObject tentacle_shadow = new GameObject("Tentacle_Shadow"); //make new shadow
            tentacle_shadow.transform.parent = gameObject.transform; //add this object as parent
            tentacle_shadow.AddComponent<scr_tentacle>(); //add script to shadow object
            tentacle_shadow.GetComponent<scr_tentacle>().tentacleMaterial = shadowMaterial; //add material to shadow object

            current++; //add one root to count
            doOnce = true; //unlock the loop
        }
    }
    IEnumerator detach()
    {
        yield return new WaitForSeconds(20); //wait 20 seconds until ripe
        detatched = true; //do not follow root anymore
        rigidBody.AddForce(ejectForce, ForceMode.Impulse); //add force to any direction
        doOnce = true; //activate sprouting
    }
}
