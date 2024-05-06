using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private GameManager gameManager;
    private CardScaler cardScaler;

    public int currentDifficulty;
    
    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        cardScaler = GetComponent<CardScaler>();

        currentDifficulty = PlayerPrefs.GetInt("Difficulty");
        if (currentDifficulty == 0)
        {
            currentDifficulty = 2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectedDifficulty(int difficulty)
    {
        currentDifficulty = difficulty;
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }

    public void PlayGame()
    {
        cardScaler.difficulty = PlayerPrefs.GetInt("Difficulty");
        cardScaler.spawn = true;
        StartCoroutine(gameManager.ShowLoadingScreen());
        gameManager.ShowGameUI();
    }    
}
