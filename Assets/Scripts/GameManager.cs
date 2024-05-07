using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject mainMenu;
    public GameObject gameScreen;
    public GameObject gameOverScreen;

    public GameObject homeButton;

    public TextMeshProUGUI score;
    public TextMeshProUGUI levelScore;
    public TextMeshProUGUI guessAmount;

    public int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowLoadingScreen());

        totalScore = PlayerPrefs.GetInt("Score");
        score.text = "Score : " + totalScore.ToString();
    }

    public IEnumerator ShowLoadingScreen()
    {
        //Activate Loading Screen.
        loadingScreen.SetActive(true);

        //Waits for 0.5 seconds.
        yield return new WaitForSeconds(0.5f);

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

    public void ShowGameOverUI()
    {
        StartCoroutine(GameOver());
    }

    public IEnumerator GameOver()
    {
        //Waits for 0.25 seconds.
        yield return new WaitForSeconds(0.25f);

        //Activate Loading Screen.
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
