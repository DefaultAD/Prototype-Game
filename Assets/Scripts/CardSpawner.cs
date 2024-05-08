using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    private CardPicker cardPicker;

    public Transform gridPanel;

    public GameObject cardPrefab;

    public List<Button> cardList = new List<Button>();
    public List<Sprite> spritesList = new List<Sprite>();

    public Sprite backgroundImage;
    public Sprite[] cardImages;

    [HideInInspector] public bool spawn = false;

    [HideInInspector] public int cards;
    private int spawnedCards;

    private void Start()
    {
        //Getting reference to scripts
        cardPicker = GetComponent<CardPicker>();
    }

    //Method to spawn the cards on the grid
    public void SpawnCards()
    {
        //Loop till the the amount or cards spawned reaches the amount of cards to be spawned
        if (spawnedCards <= cards - 1)
        {
            //Create new card objects in the grid panel
            GameObject card = Instantiate(cardPrefab, gridPanel.position, gridPanel.rotation, gridPanel);

            //Name each new card
            card.name = "" + spawnedCards;

            //Reflects a new card has been spawned
            spawnedCards++;

            //Find the cards for referencing
            GameObject[] cardObjects = GameObject.FindGameObjectsWithTag("Card");

            //Get the button component of each card
            cardList.Add(cardObjects[spawnedCards - 1].GetComponent<Button>());

            //Sets the sprite of each card to the background image
            cardList[spawnedCards - 1].image.sprite = backgroundImage;

            //Checks if all cards are spawned
            if (spawnedCards == cards)
            {
                //Runs the Add Listener method
                cardPicker.AddListeners();

                //Runs the Add Card Sprites method
                AddCardSprites();

                //Runs the Shuffle Cards method passing sprites list
                ShuffleCards(spritesList);

                //Sets the guess amount = to the amount of cards / 2
                cardPicker.guesses = spritesList.Count / 2;

                //Stops spawning
                spawn = false;
            }
        }
    }

    //Method to shuffle the cards randomly
    void ShuffleCards(List<Sprite> list)
    {
        //Loops through the card list
        for (int i = 0; i < list.Count; i++)
        {
            //Set a temporary sprite 
            Sprite temp = list[i];

            //Get a random number 
            int randomIndex = Random.Range(i, list.Count);

            //Assigns the random number to the current card 
            list[i] = list[randomIndex];

            //Assigns the sprite that matches the number to the current card
            list[randomIndex] = temp;
        }
    }

    void AddCardSprites()
    {
        //Create a temporary variable to hold a reference to amount of cards
        int loop = cardList.Count;

        //Create a temporary variable to act as baseline
        int index = 0;

        //Loops through the card list
        for (int i = 0; i < loop; i++)
        {
            //Checks if index is = to half the amount of cards
            if (index == loop / 2)
            {
                //Reset index
                index = 0;
            }

            //Adds the card to the sprite list following the count of the index
            spritesList.Add(cardImages[index]);

            //Increases index by one
            index++;
        }
    }
}
