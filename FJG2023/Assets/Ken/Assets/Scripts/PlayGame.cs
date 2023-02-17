using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : StartScreenLogic
{
    public int order = 1;
    private void OnMouseUpAsButton()
    {
        PlayGame();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + order);
    }
}
