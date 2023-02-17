using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSesame : MonoBehaviour
{
    LogicManager logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Sprite").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameEnd()
    {

    }
}
