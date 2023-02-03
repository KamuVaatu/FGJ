using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_potato : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public LineRenderer shadowRenderer;
    private int segmentQuantity = 32;
    private Vector3[] vertexPositions;
    private Vector3[] shadowVertexPositions;
    private Vector3[] vertexSpeed;
    private Vector3 shadowOffset = new Vector2(-0.1f, -0.1f);
    private float distanceDivider;
    public Material shadowMaterial;
    private Vector3 cool;
    GameObject shadow;

    // Start is called before the first frame update
    void Start()
    {
        shadow = new GameObject("Shadow");
        shadowRenderer = shadow.AddComponent<LineRenderer>(); //assign line renderer to shadow object
        shadowRenderer.positionCount = segmentQuantity; //divisions in shadow
        shadowRenderer.material = shadowMaterial; //assign material to shadow
        shadowRenderer.startWidth = 0.5f;
        shadowRenderer.endWidth = 0.1f;

        lineRenderer.positionCount = segmentQuantity; //divisions in tentacle
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.1f;
        vertexPositions = new Vector3[segmentQuantity]; //add as many segment poses as there are divisions in tentacle
        shadowVertexPositions = new Vector3[segmentQuantity]; //add as many segment poses as there are divisions in tentacle
        vertexSpeed = new Vector3[segmentQuantity]; //add as many segment velocities as there are divisions in tentacle
    }

    // Update is called once per frame
    void Update()
    {
        cool = new Vector3(1, 1, 1);
        distanceDivider = Vector3.Distance(transform.position, cool); //get distance to target from parent
        vertexPositions[0] = transform.position; //set first segment at parent
        for (int i = 1; i < vertexPositions.Length; i++) //repeat for every segment
        {
            vertexPositions[i] = Vector3.SmoothDamp(vertexPositions[i], vertexPositions[i - 1] + cool / distanceDivider, ref vertexSpeed[i], 0.1f); //position current vertex towards last one in direction of targer at set speed
            shadowVertexPositions[i] = Vector3.SmoothDamp(shadowVertexPositions[i], shadowVertexPositions[i - 1] + (cool + shadowOffset) / distanceDivider, ref vertexSpeed[i], 0.1f); //position current shadow vertex towards last one in direction of targer at set speed
        }

        lineRenderer.SetPositions(vertexPositions); //render line
        shadowRenderer.SetPositions(shadowVertexPositions); //render shadow
    }
}
