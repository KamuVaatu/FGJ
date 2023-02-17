using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnywhere : MonoBehaviour
{
    LevelLoader level;
    void Start()
    {
        level = GetComponent<LevelLoader>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            level.LoadNextLevel(1);
        }
    }
}
