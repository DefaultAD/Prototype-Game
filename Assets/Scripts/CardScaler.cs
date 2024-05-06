using UnityEngine;
using UnityEngine.UI;

public class CardScaler : MonoBehaviour
{
    public GridLayoutGroup gridLayout;
    public Transform gridPanel;

    public GameObject cardPrefab;

    public int difficulty;
    public bool spawn = false;

    public CardLayout[] layouts;
    public CardLayout cardLayout;

    public int cards;
    public int spawnedCards;

    public int columnCount;
    public int x;
    public int y;
            
    // Start is called before the first frame update
    void Start()
    {
        gridLayout.GetComponent<GridLayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        //difficulty = PlayerPrefs.GetInt("Difficulty");
        
        if (spawn)
        {
            cardLayout = layouts[difficulty - 1];
            if (cards == 0)
            {
                cards = cardLayout.cardAmount;
                x = cardLayout.cellXSize;
                y = cardLayout.cellYSize;
                columnCount = cardLayout.columns;

                gridLayout.constraintCount = columnCount;

                gridLayout.cellSize = new Vector2(x, y);

            }
            if (spawnedCards <= cards - 1)
            {
                Instantiate(cardPrefab, gridPanel.position, gridPanel.rotation, gridPanel);
                spawnedCards++;
            }
        }
        
            
        //while (spawnedCards < cards)
        //{
        //    //instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, Spawnpoint)
        //}
    }
}
