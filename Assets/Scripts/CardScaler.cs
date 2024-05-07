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
        gridLayout.GetComponent<GridLayoutGroup>();
        cardSpawner = GetComponent<CardSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //difficulty = PlayerPrefs.GetInt("Difficulty");
        
        if (cardSpawner.spawn)
        {
            cardLayout = layouts[difficulty - 1];
            if (cardSpawner.cards == 0)
            {
                cardSpawner.cards = cardLayout.cardAmount;
                x = cardLayout.cellXSize;
                y = cardLayout.cellYSize;
                columnCount = cardLayout.columns;

                gridLayout.constraintCount = columnCount;

                gridLayout.cellSize = new Vector2(x, y);
            }
            cardSpawner.SpawnCards();
        }
    }
}
