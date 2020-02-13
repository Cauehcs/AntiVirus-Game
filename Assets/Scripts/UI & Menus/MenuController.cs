using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] string currentScene, nextScene;
    [SerializeField]bool canGoMenu, canBackMenu;
    static bool creditsToMenu;

    [SerializeField] private GameObject[] canvasMenu;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        if(currentScene == "Menu" && !creditsToMenu) StartCoroutine(Timer(0));
        else if (currentScene == "Credits") canBackMenu = true;
    }

    private void Update()
    {
        if (currentScene == "Menu") StartMenuBehaviour();
        else if (currentScene == "Credits") CreditsBehaviour();
    }

    void CreditsBehaviour()
    {
        if(canBackMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            creditsToMenu = true;
            SceneManager.LoadScene("Menu");
        }
    }

    void StartMenuBehaviour()
    {
        if (creditsToMenu)
        {
            canvasMenu[1].SetActive(true);
        }

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
        SceneManager.LoadScene("Credits"); creditsToMenu = false;
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
