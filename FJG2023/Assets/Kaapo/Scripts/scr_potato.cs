using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_potato : MonoBehaviour
{
    public float randomX;
    public float randomY;
    private int generateThisMany;
    private int current;
    private bool doOnce;
    public Material tentacleMaterial;
    public Material shadowMaterial;


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
            randomX = Random.Range(-4, 4);
            randomY = Random.Range(-4, 4);

            yield return new WaitForSeconds(1); //wait this long to create new tentacle
            GameObject tentacle = new GameObject("Tentacle");
            tentacle.transform.parent = gameObject.transform;
            tentacle.tag = "tag_tentacle";
            tentacle.AddComponent<scr_tentacle>();
            tentacle.GetComponent<scr_tentacle>().tentacleMaterial = tentacleMaterial;

            GameObject tentacle_shadow = new GameObject("Tentacle_Shadow");
            tentacle_shadow.transform.parent = gameObject.transform;
            tentacle_shadow.AddComponent<scr_tentacle>();
            tentacle_shadow.GetComponent<scr_tentacle>().tentacleMaterial = shadowMaterial;

            current++;
            doOnce = false;
        }
    }
}
