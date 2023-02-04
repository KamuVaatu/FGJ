using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tentacle : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private int segmentQuantity = 32;
    private Vector3[] vertexPositions;
    private Vector3[] vertexSpeed;
    private float distanceDivider;
    public Vector3 target;
    private Vector3 positionOffset;
    public Material tentacleMaterial;
    public Material shadowMaterial;
    private int attachSegment;
    private Vector3 attachPoint;
    private GameObject[] potatoes;
    private int potatoesGrown;
    private bool oneAtATime;
    public Sprite potatoSprite;
    public SpriteRenderer spriteRenderer;
    private int fruitAtRandom;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "tag_tentacle")
        {
            positionOffset = new Vector3(0.01f, 0.01f);
            oneAtATime = true;
        }
        else
        {
            positionOffset = new Vector3(0, 0);
        }
        target = new Vector3(transform.parent.GetComponent<scr_bad_potato>().randomX, transform.parent.GetComponent<scr_bad_potato>().randomY, 0);
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0f;
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
            StartCoroutine(readyToFruit());
            oneAtATime = false;
        }
        
        distanceDivider = Vector3.Distance(transform.parent.position, target); //get distance to target from parent
        vertexPositions[0] = transform.parent.position; //set first segment at parent
        Debug.Log(vertexPositions[0]);
        for (int i = 1; i < vertexPositions.Length; i++) //repeat for every segment
        {
            vertexPositions[i] = Vector3.SmoothDamp(vertexPositions[i], vertexPositions[i - 1] + target + transform.parent.position / distanceDivider + positionOffset, ref vertexSpeed[i], 2f); //position current vertex towards last one in direction of targer at set speed
            if (i == attachSegment) //collect data from right segment
            {
                attachPoint = vertexPositions[i]; //add to attachpoint
            }
        }
        lineRenderer.SetPositions(vertexPositions); //render line
    }
    IEnumerator readyToFruit()
    {
        fruitAtRandom = Random.Range(10, 20);
        yield return new WaitForSeconds(fruitAtRandom); //wait 20 seconds until fruits sprout
        GameObject potato = new GameObject ("bad_potato");
        potato.AddComponent<scr_bad_potato>();
        potato.AddComponent<SpriteRenderer>();
        potato.AddComponent<scr_bad_potato>().spriteRenderer = spriteRenderer;
        potato.GetComponent<scr_bad_potato>().potatoSprite = potatoSprite;
        potato.GetComponent<scr_bad_potato>().tentacleMaterial = tentacleMaterial;
        potato.GetComponent<scr_bad_potato>().shadowMaterial = shadowMaterial;
        potato.GetComponent<scr_bad_potato>().rigidBody = potato.AddComponent<Rigidbody>();
        potato.GetComponent<scr_bad_potato>().potatoSprite = potatoSprite; //return sprite stored from the parent to child
        //potatoes[potatoesGrown] = potato;

        attachSegment = Random.Range(0,vertexPositions.Length); //select random segment for potato to spawn from
        oneAtATime = true;
    }
}
