using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour
{
    // holts all fliping cards process 
    public static bool DO_NOT = false;
    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    [SerializeField]
    private GameManager gameManagerScript;

    private bool firstCardClicked;
    private bool firstCardClickedSecondTime;

    private bool playedAnimationForCorrect;
    private bool runnedOnce;

    Animator animator;

    AudioSource sound;

    public AudioClip winning;
    public AudioClip losing;

    public int numOfClicksForFirstCard = 0;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// initialising all values
    /// </summary>
    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);
        flipCard();
    }

    public void flipCard()
    {
        // && gameManagerScript.finishedTutorial
        if (_state == 0 )
            _state = 1;
        else if (_state == 1 )
            _state = 0;

        // if state = 0 ( means card is faced up ) then flip it back
        if (_state == 0 && !DO_NOT) GetComponent<Image>().sprite = _cardBack;
        // if state 1 ( means car is faced down ) then flip it up
        else if (_state == 1 && !DO_NOT) GetComponent<Image>().sprite = _cardFace;
    }

    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    // gives a little buffer when the cards is flipped over and check if it is a match and how long the card should wait until flipped again
    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0) GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1) GetComponent<Image>().sprite = _cardFace;
        DO_NOT = false;
    }

    private bool runned;
    public void firstCard()
    {
        firstCardClicked = true;
        GetComponent<Image>().sprite = _manager.GetComponent<GameManager>().getCardFace(_cardValue);
        animator.SetTrigger("OriginalCardState");
        int indexOfMatchingCard = gameManagerScript.getIndexOfMatchingFirstCard(_cardFace.name);
        if (!runned)
            gameManagerScript.playAnimationForWrongMatch();
        runned = true;


    }

    
    public void setFirstCardClickedSecondTimeToTrue()
    {
        numOfClicksForFirstCard++;
        
        if (numOfClicksForFirstCard == 2)
            gameManagerScript.playAnimationForCorrectgMatch();
    }


    public void stopAndPlayAnimation()
    {


        if (gameManagerScript.cards[0].GetComponent<Image>().sprite.name == GetComponent<Image>().sprite.name)
        {
            gameManagerScript.finishedTutorial = true;
            sound.PlayOneShot(winning);
            animator.SetTrigger("OriginalCardState");
        }

        if ( (gameManagerScript.cards[0].GetComponent<Image>().sprite.name != GetComponent<Image>().sprite.name) && (!gameManagerScript.finishedTutorial) )
        {
            animator.SetTrigger("OriginalCardState");
            sound.PlayOneShot(losing);
            gameManagerScript.playAnimationForOriginalCard();
        }


    }



    void playLosingSound()
    {
        sound.PlayOneShot(losing);
    }

    void playWinningSound()
    {
        sound.PlayOneShot(winning);
    }

    public Sprite getCardFace()
    {
        return _cardFace;
    }

    public Sprite getCardBack()
    {
        return _cardBack;
    }
}