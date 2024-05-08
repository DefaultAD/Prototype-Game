using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerV2 : MonoBehaviour
{
    public List<GameObject> cards;

    public int card1;
    public GameObject card1GO;

    public int card2;
    public GameObject card2GO;

    public int matchNumber;

    public bool card1Selected;
    public bool card2Selected;
    public bool noMatch;
    public bool reset;

    public AudioController audioController;
    
    private void Start()
    {
        audioController = FindObjectOfType<AudioController>();

        cards.AddRange(GameObject.FindGameObjectsWithTag("Card"));        
    }

    private void Update()
    {
        if (reset)
        {
            noMatch = false;
            reset = false;            
        }

        if (card1 != 0)
        {
            matchNumber = card1;
            card1Selected = true;
        }
        if (card2 != 0)
        {
            card2Selected = true;
        }

        if (card1Selected && card2Selected)
        {
            if (card1 == card2)
            {
                StartCoroutine(MatchingCards());                
            }
            else
            {
                ResetStats();
            }
        }

        if (cards.Count == 0)
        {
            StartCoroutine(RestartGame());
        }
    }

    public void ResetStats()
    {
        noMatch = true;

        matchNumber = 0;
        card1 = 0;
        card1GO = null;
        card1Selected = false;
        card2 = 0;
        card2GO = null;
        card2Selected = false;

        reset = true;
    }

    IEnumerator MatchingCards()
    {
        audioController.MatchCardsAudio();
        yield return new WaitForSeconds(0.1f); 
        Destroy(card1GO);
        Destroy(card2GO);
        cards.RemoveAll(GameObject => GameObject == null);

        yield return new WaitForSeconds(0.1f);
        ResetStats();
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
