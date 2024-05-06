using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private GameManager gameManager;

    public int currentDifficulty;
    
    void Awake()
    {
        gameManager = GetComponent<GameManager>();

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
        StartCoroutine(gameManager.ShowLoadingScreen());
    }    
}
