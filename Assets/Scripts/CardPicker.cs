using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CardPicker : MonoBehaviour
{
    private CardSpawner cardSpawner;
    private GameManager gameManager;
    private AudioController audioController;

    private bool firstGuess;
    private bool secondGuess;

    private int guessCount;
    private int guessCountCorrect;
    public int guesses;

    private int firstGuessIndex;
    private int secondGuessIndex;

    private string firstGuessCard;
    private string secondGuessCard;

    private int combo;
    private int totalScore;
    private int gameScore;

    private int gameScoreCombo;

    int timer;

    // Start is called before the first frame update
    void Start()
    {
        cardSpawner = GetComponent<CardSpawner>();
        gameManager = GetComponent<GameManager>();
        audioController = GetComponent<AudioController>();

        totalScore = PlayerPrefs.GetInt("Score");
        //if (!newGame)
        //{
        //  //create a way to save the score
        //}
        //else
        gameScore = 0;
        combo = 1;
    }

    public void AddListeners()
    {
        foreach (Button cards in cardSpawner.cardList)
        {
            cards.onClick.AddListener(() => PickACard());
        }
    }

    public void PickACard()
    {
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessCard = cardSpawner.spritesList[firstGuessIndex].name;
            cardSpawner.cardList[firstGuessIndex].image.sprite = cardSpawner.spritesList[firstGuessIndex];
            audioController.FlipCardAudio();
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessCard = cardSpawner.spritesList[secondGuessIndex].name;
            cardSpawner.cardList[secondGuessIndex].image.sprite = cardSpawner.spritesList[secondGuessIndex];
            audioController.FlipCardAudio();

            guessCount++;
            StartCoroutine(CheckMatch());            
        }        
    }
    
    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(0.01f);

        int lastFirstIndex = firstGuessIndex;
        int lastSecondIndex = secondGuessIndex;

        if (firstGuessCard == secondGuessCard && firstGuessIndex != secondGuessIndex)
        {
            combo++;
            gameScore++;

            gameScoreCombo = gameScore * combo;

            audioController.MatchCardsAudio();

            yield return new WaitForSeconds(0.5f);

            cardSpawner.cardList[lastFirstIndex].interactable = false;
            cardSpawner.cardList[lastSecondIndex].interactable = false;

            cardSpawner.cardList[lastFirstIndex].image.color = new Color(0,0,0,0);
            cardSpawner.cardList[lastSecondIndex].image.color = new Color(0, 0, 0, 0);

            firstGuess = false;
            secondGuess = false;

            CheckIfComplete();
        }
        else
        {
            combo = 1;

            firstGuess = false;
            secondGuess = false;

            audioController.MismatchCardsAudio();

            yield return new WaitForSeconds(0.5f);

            cardSpawner.cardList[lastFirstIndex].image.sprite = cardSpawner.backgroundImage;
            cardSpawner.cardList[lastSecondIndex].image.sprite = cardSpawner.backgroundImage;
        }

        yield return new WaitForSeconds(0.01f);

        //firstGuess = false;
        //secondGuess = false;
    }

    void CheckIfComplete()
    {
        guessCountCorrect++;
        PlayerPrefs.SetInt("Score", totalScore + gameScoreCombo);

        if (guessCountCorrect == guesses) 
        {
            audioController.GameOverAudio();

            gameManager.ShowGameOverUI();

            gameManager.levelScore.text = "+" + gameScoreCombo;
            gameManager.guessAmount.text = "It took " + guessCount + " guesses";
        }
    }
}
