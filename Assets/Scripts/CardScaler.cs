using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardScaler : MonoBehaviour
{
    public GameObject gridLayout;

    public int difficulty;
    public CardLayout[] layouts;
    public CardLayout cardLayout;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");
        cardLayout = layouts[difficulty];

        gridLayout.GetComponent<GridLayout>();
        cardLayout.GetComponent<CardLayout>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
