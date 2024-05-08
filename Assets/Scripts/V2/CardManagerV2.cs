using UnityEngine;

public class CardManagerV2 : MonoBehaviour
{
    public GameManagerV2 gameManager;
    public AudioController audioController;
    public int cardNumber;

    public bool isFlipped;
    private Animator anim;

    void Start()
    {
        gameManager = FindObjectOfType<GameManagerV2>();
        audioController = FindObjectOfType<AudioController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isFlipped && gameManager.noMatch == true)
        {
            audioController.MismatchCardsAudio();
            anim.Play("UnFlipCard");
            isFlipped = false;
        }
    }

    void OnMouseDown()
    {
        if (!isFlipped)
        {
            if(gameManager.card1Selected == false)
            {
                gameManager.card1 = cardNumber;
                gameManager.card1GO = this.gameObject;
            }
            else
            {
                gameManager.card2 = cardNumber;
                gameManager.card2GO = this.gameObject;
            }
            audioController.FlipCardAudio();
            anim.Play("FlipCard");
            isFlipped = true;
        }
        else if (isFlipped && gameManager.noMatch)
        {
            audioController.MismatchCardsAudio();
            anim.Play("UnFlipCard");
            isFlipped = false;
        }
    }
}
