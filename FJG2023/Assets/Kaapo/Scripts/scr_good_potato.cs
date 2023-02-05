using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_good_potato : MonoBehaviour
{
    public Material shadowMaterial;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public Sprite[] potatoSprite;
    private int attachSegment;
    private Vector3 potatoOffset;

    // Start is called before the first frame update
    void Start()
    {
        attachSegment = Random.Range(0, transform.parent.GetComponent<scr_tentacle>().segmentQuantity);
        gameObject.AddComponent<scr_shadows>(); //add shadows
        gameObject.GetComponent<scr_shadows>().shadowMaterial = shadowMaterial; //assign shadow material
        potatoOffset = new Vector3(Random.Range(0.5f, -0.5f), Random.Range(0.5f, -0.5f), 0); //potato growth offset
        gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f); //start from small
        rigidBody.angularDrag = 0f; //remove drag
        rigidBody.gravityScale = 0;
        rigidBody.angularDrag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x < 1) //grow until full size
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x + 1.00001f * Time.deltaTime, transform.localScale.y + 1.00001f * Time.deltaTime, transform.localScale.z + 1.00001f * Time.deltaTime); //grow potato slowly
        }

        transform.position = transform.parent.GetComponent<scr_tentacle>().vertexPositions[attachSegment] + potatoOffset;
    }
}
