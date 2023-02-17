using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject rottenPotato;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NeverEnd", 2f, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NeverEnd()
    {
        Instantiate(rottenPotato, new Vector3(6, -7, 0), transform.rotation);
    }
}
