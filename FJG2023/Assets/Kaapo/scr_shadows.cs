using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_shadows : MonoBehaviour
{
    private Vector3 positionOffset = new Vector2(-1f, -1f);
    GameObject shadow;
    public Material shadowMaterial;

    // Start is called before the first frame update
    void Start()
    {
        shadow = new GameObject("Shadow"); //create game object named shadow

        SpriteRenderer renderer = GetComponent<SpriteRenderer>(); //fetch renderer
        SpriteRenderer shadowRenderer = shadow.AddComponent<SpriteRenderer>(); //add object to renderer
        shadowRenderer.sprite = renderer.sprite; //assign sprite
        shadowRenderer.material = shadowMaterial; //assign material
    }

    // Update is called once per frame
    void Update()
    {
        shadow.transform.position = transform.position + positionOffset; //position to parent with offset
        shadow.transform.rotation = transform.rotation; //same rotation as parent
    }
}
