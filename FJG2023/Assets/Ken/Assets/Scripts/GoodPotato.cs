using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPotato : MonoBehaviour
{
    private LogicManager logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // keraa perunan jos inventory ei ole taynna
    public void PickUp()
    {
        if(logic.IsBagFull() == true)
        {
            return;
        }

        logic.AddPotato();

        //somekinda animation here.

        Destroy(gameObject);
    }
}
