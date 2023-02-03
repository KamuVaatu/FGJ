using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_potato : MonoBehaviour
{


    private float randomX;
    private float randomY;
    private int generateThisMany;
    private int current;
    private bool doOnce;

    // Start is called before the first frame update
    void Start()
    {
        generateThisMany = Random.Range(16, 16);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(current);

        if (doOnce == false)
        {
            StartCoroutine(addTentacle());
            doOnce = true;
        }
    }

    IEnumerator addTentacle()
    {
        if (current != generateThisMany)
        {
            yield return new WaitForSeconds(1); //wait this long to create new tentacle
            GameObject tentacle = new GameObject("Tentacle");
            tentacle.transform.parent = gameObject.transform;
            tentacle.AddComponent<scr_tentacle>();
            current++;
            doOnce = false;
        }
    }
}
