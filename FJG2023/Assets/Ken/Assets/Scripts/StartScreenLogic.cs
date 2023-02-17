using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenLogic : MonoBehaviour
{
    public Transform highLight;
    SpriteRenderer spriterenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        //Audioclip here
        highLight.gameObject.SetActive(true);
        spriterenderer.color= Color.gray;
    }

    private void OnMouseExit()
    {
        highLight.gameObject.SetActive(false);
        spriterenderer.color = Color.white;
    }
}
