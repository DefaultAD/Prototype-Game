using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject mainMenu;
    public GameObject gameScreen;

    public GameObject homeButton;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowLoadingScreen());
    }

    public IEnumerator ShowLoadingScreen()
    {
        //Activate Loading Screen.
        loadingScreen.SetActive(true);

        //Waits for 2 seconds.
        yield return new WaitForSeconds(1);

        //Deactivate Loading Screen.
        loadingScreen.SetActive(false);
    }

    public void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameScreen.SetActive(true);
        homeButton.SetActive(true);
    }

    public void ShowMainMenuUI()
    {
        mainMenu.SetActive(true);
        gameScreen.SetActive(false);
        homeButton.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
