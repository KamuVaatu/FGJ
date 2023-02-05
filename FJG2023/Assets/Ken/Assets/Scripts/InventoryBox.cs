using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBox : MonoBehaviour
{
    LogicManager logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    public void ReceivePotatoes()
    {
        logic.Unload();
    }
}
