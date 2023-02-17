using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpriteChange : MonoBehaviour
{
    public Sprite[] potatoEnemy6 = new Sprite[3];
    public Sprite[] potatoEnemy7 = new Sprite[3];
    public Sprite[] potatoEnemy8 = new Sprite[3];
    public Sprite[] potatoEnemy9 = new Sprite[3];
    public Sprite[] potatoEnemy10 = new Sprite[3];
    public Sprite[] potatoEnemy11 = new Sprite[3];

    public Sprite[] DetectPotatoSprite(string potato)
    {
        Debug.Log(potato);
        if (potato == "Potatoes_6 (UnityEngine.Sprite)")
        {
            return potatoEnemy6;
        }
        else if (potato == "Potatoes_7 (UnityEngine.Sprite)")
        {
            return potatoEnemy7;
        }
        else if (potato == "Potatoes_8 (UnityEngine.Sprite)")
        {

            return potatoEnemy8;
        }
        else if (potato == "Potatoes_9 (UnityEngine.Sprite)")
        {
            return potatoEnemy9;
        }
        else if (potato == "Potatoes_10 (UnityEngine.Sprite)")
        {
            return potatoEnemy10;
        }
        else
        {
            return potatoEnemy11;
        }
    }
}
