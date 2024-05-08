using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject continueScreen;
    public GameObject mainMenu;
    public GameObject gameScreen;
    public GameObject gameOverScreen;

    public GameObject homeButton;
    public GameObject exitButton;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI levelScoreText;
    public TextMeshProUGUI guessAmountText;

    public int totalScore;
    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        //Starts the ShowLoadingScreen coroutine
        StartCoroutine(ShowLoadingScreen());

        //Loads total score
        totalScore = PlayerPrefs.GetInt("Score");

        //Sets the score text to reflect the current score
        scoreText.text = "Score : " + totalScore.ToString();

        //Sets the combo text element to blank
        comboText.text = "";
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
        //Set isplaying bool to true
        isPlaying = true;

        //Turns the necessary UI elements on or off
        mainMenu.SetActive(false);
        gameScreen.SetActive(true);
        homeButton.SetActive(true);
        exitButton.SetActive(false);
        continueScreen.SetActive(false);
    }

    public void ShowMainMenuUI()
    {
        //Set isplaying bool to false
        isPlaying = false;

        //Sets the combo text element to blank
        comboText.text = "";

        //Turns the necessary UI elements on or off 
        mainMenu.SetActive(true);
        gameScreen.SetActive(false);
        homeButton.SetActive(false);
        exitButton.SetActive(true);
        continueScreen.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        //Set isplaying bool to false
        isPlaying = false;

        //Starts the GameOveer coroutine
        StartCoroutine(GameOver());
    }

    public IEnumerator GameOver()
    {
        //Set isplaying bool to false
        isPlaying = false;

        //Waits for 0.25 seconds
        yield return new WaitForSeconds(0.25f);

        //Activate Loading Screen
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        //Reloads the scene
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
