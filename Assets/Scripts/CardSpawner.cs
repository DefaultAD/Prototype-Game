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
        cardPicker = GetComponent<CardPicker>();
    }

    public void SpawnCards()
    {
        if (spawnedCards <= cards - 1)
        {
            GameObject card = Instantiate(cardPrefab, gridPanel.position, gridPanel.rotation, gridPanel);
            card.name = "" + spawnedCards;
            spawnedCards++;

            GameObject[] cardObjects = GameObject.FindGameObjectsWithTag("Card");
            cardList.Add(cardObjects[spawnedCards - 1].GetComponent<Button>());
            cardList[spawnedCards - 1].image.sprite = backgroundImage;

            if (spawnedCards == cards)
            {
                cardPicker.AddListeners();
                AddCardSprites();
                ShuffleCards(spritesList);
                cardPicker.guesses = spritesList.Count / 2;
                spawn = false;
            }
        }
    }

    void ShuffleCards(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void AddCardSprites()
    {
        int loop = cardList.Count;
        int index = 0;

        for (int i = 0; i < loop; i++)
        {
            if (index == loop / 2)
            {
                index = 0;
            }

            spritesList.Add(cardImages[index]);
            index++;
        }
    }
}
