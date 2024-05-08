using System;
using System.Collections;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject CardPrefab;

    public Transform gridPanel;

    public int rows;
    public int columns;

    public float tileSize = 1;
    private int spawnedCards;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {        
        for (int row = 0; row < rows; row++) 
        {
            for (int col = 0; col < columns; col++)
            {
                GameObject newCard = Instantiate(CardPrefab, gridPanel.position, gridPanel.rotation, gridPanel);
                //Name each new card
                newCard.name = "" + spawnedCards / 2;
                //Reflects a new card has been spawned
                spawnedCards++;

                float posX = col * tileSize;
                float posY = row * -tileSize;

                newCard.transform.position = new Vector2(posX, posY);
            }
        }

        float gridW = columns * tileSize;
        float gridH = rows * tileSize;
        gridPanel.transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
    }   
}
