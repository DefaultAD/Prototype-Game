using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private GameManager gameManager;
    private CardScaler cardScaler;
    private CardSpawner cardSpawner;

    public int currentDifficulty;
    
    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        cardScaler = GetComponent<CardScaler>();
        cardSpawner = GetComponent<CardSpawner>();

        currentDifficulty = PlayerPrefs.GetInt("Difficulty");
        if (currentDifficulty == 0)
        {
            currentDifficulty = 2;
        }
    }

    public void SelectedDifficulty(int difficulty)
    {
        currentDifficulty = difficulty;
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }

    public void PlayGame()
    {
        cardScaler.difficulty = PlayerPrefs.GetInt("Difficulty");
        cardSpawner.spawn = true;
        StartCoroutine(gameManager.ShowLoadingScreen());
        gameManager.ShowGameUI();
    }    
}
