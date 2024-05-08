using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScaler : MonoBehaviour
{
    private CardSpawner cardSpawner;

    public GridLayoutGroup gridLayout;

    [HideInInspector] public int difficulty;

    public CardLayout[] layouts;
    [HideInInspector] public CardLayout cardLayout;

    [HideInInspector] public int columnCount;
    [HideInInspector] public int x;
    [HideInInspector] public int y;
            
    // Start is called before the first frame update
    void Start()
    {
        //Getting reference to scripts
        gridLayout.GetComponent<GridLayoutGroup>();
        cardSpawner = GetComponent<CardSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if can spawn
        if (cardSpawner.spawn)
        {
            //Setting the card layout from the sellected difficulty
            cardLayout = layouts[difficulty - 1];

            //Checking if is existing data
            if (cardSpawner.cards == 0)
            {
                //Setting the amount of cards to spawn
                cardSpawner.cards = cardLayout.cardAmount;

                //Setting the X size of the cell(cards)
                x = cardLayout.cellXSize;

                //Setting the Y size of the cell(cards)
                y = cardLayout.cellYSize;

                //Setting the amount of colums
                columnCount = cardLayout.columns;

                //Applying the cell(card) size to the grid
                gridLayout.cellSize = new Vector2(x, y);

                //Applying the column count to the grid
                gridLayout.constraintCount = columnCount;
            }

            //Running the spawning method
            cardSpawner.SpawnCards();
        }
    }
}
