using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Animator transition;
    [SerializeField]
    private float transitionTime;
    
    public void LoadNextLevel(int index)
    {
        Debug.Log("Hi");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + index)) ;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    

}
