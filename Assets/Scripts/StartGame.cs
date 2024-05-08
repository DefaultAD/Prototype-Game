using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    private GameManager gameManager;
    private CardScaler cardScaler;
    private CardSpawner cardSpawner;

    public int currentDifficulty;
    
    void Awake()
    {
        //Getting reference to scripts
        gameManager = GetComponent<GameManager>();
        cardScaler = GetComponent<CardScaler>();
        cardSpawner = GetComponent<CardSpawner>();

        //Loads and sets the difficulty level
        currentDifficulty = PlayerPrefs.GetInt("Difficulty");

        //Checks if a difficulty has been loaded
        if (currentDifficulty == 0)
        {
            //If no difficulty has been loaded set the difficulty to 2 (default)
            currentDifficulty = 2;
        }
    }

    public void SelectedDifficulty(int difficulty)
    {
        //Stores the difficulty level
        currentDifficulty = difficulty;

        //Saves the difficulty level
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }

    public void PlayGame()
    {
        //Loads and sets the difficulty level
        cardScaler.difficulty = PlayerPrefs.GetInt("Difficulty");

        //Sets bool to start spawning
        cardSpawner.spawn = true;

        //Shows the loading screen while cards spawn
        StartCoroutine(gameManager.ShowLoadingScreen());

        //Activates the game UI
        gameManager.ShowGameUI();
    }    

    public void LoadV2()
    {
        SceneManager.LoadScene(1);
    }
}
