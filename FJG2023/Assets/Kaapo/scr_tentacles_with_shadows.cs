using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tent : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public LineRenderer shadowRenderer;
    private int segmentQuantity = 32;
    private Vector3[] vertexPositions;
    private Vector3[] shadowVertexPositions;
    private Vector3[] vertexSpeed;
    private Vector3 shadowOffset = new Vector2(-5f, -5f);
    private float distanceDivider;
    public Material shadowMaterial;
    public Transform target;
    public Transform parent;
    GameObject shadow;

    // Start is called before the first frame update
    void Start()
    {
        shadow = new GameObject("Shadow");
        shadowRenderer = shadow.AddComponent<LineRenderer>(); //assign line renderer to shadow object
        shadowRenderer.positionCount = segmentQuantity; //divisions in shadow
        shadowRenderer.material = shadowMaterial; //assign material to shadow

        lineRenderer.positionCount = segmentQuantity; //divisions in tentacle
        vertexPositions = new Vector3[segmentQuantity]; //add as many segment poses as there are divisions in tentacle
        shadowVertexPositions = new Vector3[segmentQuantity]; //add as many segment poses as there are divisions in tentacle
        vertexSpeed = new Vector3[segmentQuantity]; //add as many segment velocities as there are divisions in tentacle
    }

    // Update is called once per frame
    void Update()
    {
        distanceDivider = Vector3.Distance(parent.position, target.position); //get distance to target from parent
        vertexPositions[0] = parent.position; //set first segment at parent
        for (int i = 1; i < vertexPositions.Length; i++) //repeat for every segment
        {
            vertexPositions[i] = Vector3.SmoothDamp(vertexPositions[i], vertexPositions[i - 1] + target.position/distanceDivider, ref vertexSpeed[i], 0.05f); //position current vertex towards last one in direction of targer at set speed
            shadowVertexPositions[i] = Vector3.SmoothDamp(shadowVertexPositions[i], shadowVertexPositions[i - 1] + (target.position + shadowOffset) / distanceDivider, ref vertexSpeed[i], 0.05f); //position current shadow vertex towards last one in direction of targer at set speed
        }

        lineRenderer.SetPositions(vertexPositions); //render line
        shadowRenderer.SetPositions(shadowVertexPositions); //render shadow
    }
}
