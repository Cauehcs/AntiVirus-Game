using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] string currentScene, nextScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        if(currentScene == "Menu")
        {
            StartCoroutine(Timer(0));
        }
    }

    IEnumerator Timer(int TimerUse)
    {
        switch (TimerUse)
        {
            case 0:
                    yield return new WaitForSeconds(8);
                break;
        }        
    }

}
