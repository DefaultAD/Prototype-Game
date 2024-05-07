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

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI levelScoreText;
    public TextMeshProUGUI guessAmountText;

    public int totalScore;
    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        //continueScreen.SetActive(true);

        StartCoroutine(ShowLoadingScreen());

        totalScore = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score : " + totalScore.ToString();
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
        isPlaying = true;
        mainMenu.SetActive(false);
        gameScreen.SetActive(true);
        homeButton.SetActive(true);
        continueScreen.SetActive(false);
    }

    public void ShowMainMenuUI()
    {
        isPlaying = false;
        comboText.text = "";
        mainMenu.SetActive(true);
        gameScreen.SetActive(false);
        homeButton.SetActive(false);
        continueScreen.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        isPlaying = false;
        StartCoroutine(GameOver());
    }

    public IEnumerator GameOver()
    {
        isPlaying = false;
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
