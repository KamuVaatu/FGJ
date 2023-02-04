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
    private Vector3 attachPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "tag_tentacle")
        {
            positionOffset = new Vector3(0.01f, 0.01f);
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
    }

    // Update is called once per frame
    void Update()
    {
        distanceDivider = Vector3.Distance(transform.parent.position, target); //get distance to target from parent
        vertexPositions[0] = transform.parent.position; //set first segment at parent
        for (int i = 1; i < vertexPositions.Length; i++) //repeat for every segment
        {
            vertexPositions[i] = Vector3.SmoothDamp(vertexPositions[i], vertexPositions[i - 1] + (target + transform.parent.position / distanceDivider) * 0.01f + positionOffset, ref vertexSpeed[i], 2f); //position current vertex towards last one in direction of targer at set speed
        }
        lineRenderer.SetPositions(vertexPositions); //render line
    }
}