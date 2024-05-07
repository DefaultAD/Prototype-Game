using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPicker : MonoBehaviour
{
    private CardSpawner cardSpawner;

    private bool firstGuess;
    private bool secondGuess;

    private int guessCount;
    private int guessCountCorrect;
    [HideInInspector] public int guesses;

    private int firstGuessIndex;
    private int secondGuessIndex;

    private string firstGuessCard;
    private string secondGuessCard;

    // Start is called before the first frame update
    void Start()
    {
        cardSpawner = GetComponent<CardSpawner>();
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

        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessCard = cardSpawner.spritesList[secondGuessIndex].name;
            cardSpawner.cardList[secondGuessIndex].image.sprite = cardSpawner.spritesList[secondGuessIndex];

            guessCount++;
            StartCoroutine(CheckMatch());
            if (firstGuessCard == secondGuessCard)
            {
                Debug.Log("Match");
            }
            else
            {
                Debug.Log("No Match");
            }
        }        
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(0.01f);

        if (firstGuessCard == secondGuessCard)
        {
            yield return new WaitForSeconds(0.5f);

            cardSpawner.cardList[firstGuessIndex].interactable = false;
            cardSpawner.cardList[secondGuessIndex].interactable = false;

            cardSpawner.cardList[firstGuessIndex].image.color = new Color(0,0,0,0);
            cardSpawner.cardList[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfComplete();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            cardSpawner.cardList[firstGuessIndex].image.sprite = cardSpawner.backgroundImage;
            cardSpawner.cardList[secondGuessIndex].image.sprite = cardSpawner.backgroundImage;
        }

        yield return new WaitForSeconds(0.01f);

        firstGuess = false;
        secondGuess = false;
    }

    void CheckIfComplete()
    {
        guessCountCorrect++;

        if (guessCountCorrect == guesses) 
        {
            Debug.Log("End");
            Debug.Log("It took " + guessCount + " many guesses");
        }
    }
}
