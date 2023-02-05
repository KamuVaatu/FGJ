using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tentacle : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int segmentQuantity = 32;
    public Vector3[] vertexPositions;
    private Vector3[] vertexSpeed;
    public Vector3 target;
    private float positionOffset;
    public Material tentacleMaterial;
    public Material shadowMaterial;
    private bool oneAtATime;
    public Sprite[] potatoSprite;
    private int fruitAtRandom;
    private int randomBad;
    private int randomGood;
    public float randomX;
    public float randomY;

    // Start is called before the first frame update
    void Start()
    {
        randomX = transform.parent.GetComponent<scr_bad_potato>().randomX;
        randomY = transform.parent.GetComponent<scr_bad_potato>().randomY;
        //randomY = Random.Range(-0.5f, 0.5f); //direction, in which the tentacle will grow

        if (gameObject.tag == "tag_tentacle")
        {
            oneAtATime = true;
        }
        else
        {
            positionOffset = 0.1f;
        }
        target = new Vector3(transform.position.x + randomX + positionOffset, transform.position.y + randomY + positionOffset, 0);
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.material = tentacleMaterial;
        lineRenderer.positionCount = segmentQuantity; //divisions in tentacle
        vertexPositions = new Vector3[segmentQuantity]; //add as many segment poses as there are divisions in tentacle
        vertexSpeed = new Vector3[segmentQuantity]; //add as many segment velocities as there are divisions in tentacle

        for (int i = 1; i < vertexPositions.Length; i++) //repeat for every segment
        {
            vertexPositions[i] = transform.parent.position; //position all segments to middle of potato
        }
        lineRenderer.SetPositions(vertexPositions); //render line
    }

    // Update is called once per frame
    void Update()
    {
        if (oneAtATime == true)
        {
            StartCoroutine(readyToFruitBad());
            StartCoroutine(readyToFruitGood());
            oneAtATime = false;
        }
        
        vertexPositions[0] = transform.parent.position; //set first segment at parent
        for (int i = 1; i < vertexPositions.Length; i++) //repeat for every segment
        {
            vertexPositions[i] = Vector3.SmoothDamp(vertexPositions[i], vertexPositions[i - 1] + target, ref vertexSpeed[i], 0.1f); //position current vertex towards last one in direction of targer at set speed
        }
        lineRenderer.SetPositions(vertexPositions); //render line
    }
    
    IEnumerator readyToFruitBad()
    {
        randomBad = Random.Range(6, 11);
        fruitAtRandom = Random.Range(10, 20);
        yield return new WaitForSeconds(fruitAtRandom); //wait 20 seconds until fruits sprout
        GameObject bad_potato = new GameObject ("bad_potato");
        bad_potato.AddComponent<scr_bad_potato>();
        SpriteRenderer renderer = bad_potato.AddComponent<SpriteRenderer>();
        renderer.sprite = potatoSprite[randomBad];
        bad_potato.GetComponent<scr_bad_potato>().tentacleMaterial = tentacleMaterial;
        bad_potato.GetComponent<scr_bad_potato>().shadowMaterial = shadowMaterial;
        //bad_potato.GetComponent<scr_bad_potato>().rigidBody = bad_potato.AddComponent<Rigidbody>();
        bad_potato.GetComponent<scr_bad_potato>().rigidBody = bad_potato.AddComponent<Rigidbody2D>();
        bad_potato.GetComponent<scr_bad_potato>().potatoSprite = potatoSprite; //return sprite stored from the parent to child
        bad_potato.transform.parent = gameObject.transform;
    }
    
    IEnumerator readyToFruitGood()
    {
        for (int i = Random.Range(0, 4); i >= 0; i--)
        {
            randomGood = Random.Range(0, 5);
            fruitAtRandom = Random.Range(10, 20);
            yield return new WaitForSeconds(fruitAtRandom); //wait 20 seconds until fruits sprout
            GameObject good_potato = new GameObject("good_potato");
            good_potato.AddComponent<scr_good_potato>();
            SpriteRenderer renderer = good_potato.AddComponent<SpriteRenderer>();
            renderer.sprite = potatoSprite[randomGood];
            good_potato.GetComponent<scr_good_potato>().shadowMaterial = shadowMaterial;
            good_potato.GetComponent<scr_good_potato>().rigidBody = good_potato.AddComponent<Rigidbody>();
            good_potato.GetComponent<scr_good_potato>().potatoSprite = potatoSprite; //return sprite stored from the parent to child
            good_potato.transform.parent = gameObject.transform;
        }
    }
}

