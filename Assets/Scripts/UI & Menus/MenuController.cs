using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] string currentScene, nextScene;
    [SerializeField]bool canGoMenu, canBackMenu;
    int indexMenu;

    [SerializeField] private GameObject[] canvasMenu;

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

    private void Update()
    {
        StartMenuBehaviour();
    }

    void StartMenuBehaviour()
    {
        if (canGoMenu)
        {
            print("CanGoMenu Actived!");
            if (Input.anyKey && !Input.GetKey(KeyCode.Escape))
            {
                canvasMenu[1].SetActive(true);
                canBackMenu = true;
            }
        }

        if (canBackMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canvasMenu[1].GetComponent<Animator>().speed = -1;
                canBackMenu = false;
            }
        }   
    }

    public void GoFaseOneButton()
    {
        SceneManager.LoadScene("Fase One");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator Timer(int TimerUse)
    {
        switch (TimerUse)
        {
            case 0:
                    yield return new WaitForSeconds(8);
                    canGoMenu = true;
                break;
        }        
    }

}
