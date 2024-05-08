using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardPicker : MonoBehaviour
{
    private CardScaler cardScaler;
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

    void Start()
    {
        //Getting reference to scripts
        cardScaler = GetComponent<CardScaler>();
        cardSpawner = GetComponent<CardSpawner>();
        gameManager = GetComponent<GameManager>();
        audioController = GetComponent<AudioController>();

        //Loading the current total score
        totalScore = PlayerPrefs.GetInt("Score");

        //Initializing variables
        gameScore = 0;
        combo = 1;
    }

    public void Update()
    {
        //Only show combo text when game is being played
        if (gameManager.isPlaying == true)
        {
            //Setting the text componet for the combo amount
            gameManager.comboText.text = "COMBO : x" + combo.ToString();
        }
    }

    public void AddListeners()
    {
        //Player clicks on a card
        foreach (Button cards in cardSpawner.cardList)
        {
            //Running the PickACard script on the selected card
            cards.onClick.AddListener(() => PickACard());
        }
    }

    public void PickACard()
    {
        //Pick the first card
        if (!firstGuess)
        {
            //Player made first guess
            firstGuess = true;

            //Getting the name of the first card and using it to index the card
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            //Setting the name of the card to the corresponding name in the sprite list
            firstGuessCard = cardSpawner.spritesList[firstGuessIndex].name;

            //Setting the sprite of the card to the corresponding image in the sprite list 
            cardSpawner.cardList[firstGuessIndex].image.sprite = cardSpawner.spritesList[firstGuessIndex];

            //Play the audio for card flip
            audioController.FlipCardAudio();
        }
        //Pick the second card
        else if (!secondGuess)
        {
            secondGuess = true;

            //Getting the name of the second card and using it to index the card
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            //Setting the name of the card to the corresponding name in the sprite list
            secondGuessCard = cardSpawner.spritesList[secondGuessIndex].name;

            //Setting the sprite of the card to the corresponding image in the sprite list 
            cardSpawner.cardList[secondGuessIndex].image.sprite = cardSpawner.spritesList[secondGuessIndex];

            //Play the audio for card flip
            audioController.FlipCardAudio();

            //Adding a guess to the guess count
            guessCount++;

            //Completing the guess and checking if the cards matched
            StartCoroutine(CheckMatch());            
        }        
    }
    
    IEnumerator CheckMatch()
    {
        //Creating temp variables to allow for continuous sellecting
        int lastFirstIndex = firstGuessIndex;
        int lastSecondIndex = secondGuessIndex;

        //Checking if cards are the same & if the player has sellected the same card twice
        if (firstGuessCard == secondGuessCard && lastFirstIndex != lastSecondIndex)
        {
            //Increasing the combo and gameScore variable by 1
            combo++;
            gameScore++;

            //Multiplying the gameScore by the combo variable
            gameScoreCombo = gameScore * combo;

            //Play the audio for matching cards
            audioController.MatchCardsAudio();

            //Setting bools to false to allow for next card selection
            firstGuess = false;
            secondGuess = false;

            //Waiting for 0.5 seconds
            yield return new WaitForSeconds(0.5f);
            
            //Setting the cards interactability to false
            cardSpawner.cardList[lastFirstIndex].interactable = false;
            cardSpawner.cardList[lastSecondIndex].interactable = false;
            
            //Setting the cards color to transparent
            cardSpawner.cardList[lastFirstIndex].image.color = new Color(0,0,0,0);
            cardSpawner.cardList[lastSecondIndex].image.color = new Color(0,0,0,0);

            //Running the Check If Complete method
            CheckIfComplete();
        }
        else
        {
            //Reseting the combo multiplyer
            combo = 1;
            
            //Setting bools to false to allow for next card selection
            firstGuess = false;
            secondGuess = false;

            //Play the audio for mismatching cards
            audioController.MismatchCardsAudio();

            //Waiting for 0.5 seconds
            yield return new WaitForSeconds(0.5f);

            //Setting the cards sprite back to the background image
            cardSpawner.cardList[lastFirstIndex].image.sprite = cardSpawner.backgroundImage;
            cardSpawner.cardList[lastSecondIndex].image.sprite = cardSpawner.backgroundImage;
        }
    }

    void CheckIfComplete()
    {
        //Increase the correct guess count
        guessCountCorrect++;

        //Save the new total score + the score from the game
        PlayerPrefs.SetInt("Score", totalScore + gameScoreCombo);

        //Check if the correct guesses are equal to the guesses taken
        if (guessCountCorrect == guesses)
        {
            //Play the audio for mismatching cards
            audioController.GameOverAudio();

            //Show the game over UI
            gameManager.ShowGameOverUI();

            //Update the UI with the stats from the level played
            gameManager.levelScoreText.text = " Score : " + totalScore +  " + " + gameScoreCombo;
            gameManager.guessAmountText.text = "It took " + guessCount + " guesses";
        }
    }
}
