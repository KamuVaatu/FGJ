using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bad_potato : MonoBehaviour
{
    private int generateThisMany;
    private int current;
    private bool doOnce;
    private bool detachLock;
    private bool detatched;
    public Material tentacleMaterial;
    public Material shadowMaterial;
    public Rigidbody2D rigidBody;
    private Vector3 ejectForce;
    public SpriteRenderer spriteRenderer;
    public Sprite[] potatoSprite;
    private int sproutAtRandom;
    private int attachSegment;
    private Vector3 potatoOffset;
    public float randomX;
    public float randomY;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<scr_shadows>(); //add shadows
        gameObject.GetComponent<scr_shadows>().shadowMaterial = shadowMaterial;
        potatoOffset = new Vector3(Random.Range(0.05f, -0.05f), Random.Range(0.05f, -0.05f), 0);
        if (transform.parent != null) //if the original potato
        {
            gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f); //start from nowhere
            attachSegment = Random.Range(0, transform.parent.GetComponent<scr_tentacle>().segmentQuantity);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 0); //start from nowhere
        }
        generateThisMany = Random.Range(10, 16); //amount of roots generated
        ejectForce = new Vector3(Random.Range(-1f, 1f),Random.Range(-1f, 1f),0); //force at which the potato will eject from root
        rigidBody.gravityScale = 0;
        rigidBody.angularDrag = 0;
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
            if (transform.parent != null)
            {
                if (gameObject.transform.localScale.x < 1)
                {
                    gameObject.transform.localScale = new Vector3(transform.localScale.x + 1.00001f * Time.deltaTime, transform.localScale.y + 1.00001f * Time.deltaTime, transform.localScale.z + 1.00001f * Time.deltaTime); //grow potato slowly
                }
                transform.position = transform.parent.GetComponent<scr_tentacle>().vertexPositions[attachSegment] + potatoOffset;
            }
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
            sproutAtRandom = Random.Range(10, 20);
            randomX = Random.Range(-0.5f, 0.5f); //direction, in which the tentacle will grow
            randomY = Random.Range(-0.5f, 0.5f); //direction, in which the tentacle will grow

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
        rigidBody.AddForce(ejectForce, ForceMode2D.Impulse); //add force to any direction
        transform.parent = null;
        doOnce = true; //activate sprouting
    }
}
