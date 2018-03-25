using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour
{
    // holts all fliping cards process 
    public static bool DO_NOT = false;
    [SerializeField]
    // if state = 1 then card faces down and if state = 0 then card faces up
    private int _state;
    // each pair has the same card value, so as there are 16 cards then the max for the card value will be 8
    [SerializeField]
    private int _cardValue;

    // boolean flag to check if the cards are initialised or not 
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    [SerializeField]
    private GameManager gameManagerScript;

    Animator animator;

    AudioSource sound;

    public AudioClip winning;
    public AudioClip losing;

    // this counts how many times the first card is being pressed ( for tutorial ). So when it is pressed once then 
    // the worng match will be animated and when it is being pressed for the second time then the right match will be animated
    public int numOfClicksForFirstCard = 0;

    /// <summary>
    /// always checks if cards needs to be disabled or enabled based on the state of the card 
    /// disable when card faced up
    /// enable when card faced down
    /// </summary>
    void Update()
    {
        disableAndEnableCard();
    }

    /// <summary>
    /// At the start of the scene initialise the variables for sound, state, manager and animator
    /// </summary>
    void Start()
    {
        sound = GetComponent<AudioSource>();
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// sets the vale of the card back and the card face. The card face depends on the value of the card. 
    /// cards with the same value will hav ethe same cardFace ( have the same sprite ) 
    /// </summary>
    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);
        flipCard();
    }

    /// <summary>
    /// flips the cards so when the state is 0 it dispalys the cardFace sprite and when the state is 1 then it displays the cardBack sprite
    /// </summary>
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

    /// <summary>
    /// halts the cards when there is worng matching 
    /// </summary>
    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    // gives a little buffer when the cards is flipped over and check if it is a match and how long the card should wait until flipped again
    IEnumerator pause()
    {
        yield return new WaitForSeconds(0.5f);
        if (_state == 0) GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1) GetComponent<Image>().sprite = _cardFace;
        DO_NOT = false;
    }

    private bool runned;
    /// <summary>
    /// This is called using the Unity on click functin. This function is called when the first card is clicked. 
    /// </summary>
    public void firstCard()
    {
        // stops the animation for the first card 
        animator.SetTrigger("OriginalCardState");
        // gets the index of the matching card 
        int indexOfMatchingCard = gameManagerScript.getIndexOfMatchingFirstCard(_cardFace.name);
        // if the function runs for first time then 
        if (!runned)
            // display the animation for the worng matching card 
            gameManagerScript.playAnimationForWrongMatch();
        runned = true;
    }

    /// <summary>
    /// This function is called form Unity function and increments the numOfClicksForFirstCard
    /// </summary>
    public void setFirstCardClickedSecondTimeToTrue()
    {
        numOfClicksForFirstCard++;
        
        if (numOfClicksForFirstCard == 2)
            // display the animation for the matching card
            gameManagerScript.playAnimationForCorrectgMatch();
    }


    /// <summary>
    /// This fucntion is called by all cards using Unity on click functionality 
    /// </summary>
    public void stopAndPlayAnimation()
    {
        
        // if the sprite of the first card is the same as the sprite of the card which is being clicked AND the tutorial is not over then
        if (gameManagerScript.cards[0].GetComponent<Image>().sprite.name == GetComponent<Image>().sprite.name && !gameManagerScript.finishedTutorial)
        {
            // the tutorial is finished ( as this is the last stage which should be played after the wrong match card stage )
            gameManagerScript.finishedTutorial = true;
            sound.PlayOneShot(winning);
            animator.SetTrigger("OriginalCardState");
        }

        // if the sprite of the first card is NOT the same as the sprite of the card which is being clicke AND tutorial is not over AND the number of matches is still half of all card ( which is 8 in this case )
        // so if the number of matches redued then it means that the kid figured out how to play the game and we don't want this to run
        if ( (gameManagerScript.cards[0].GetComponent<Image>().sprite.name != GetComponent<Image>().sprite.name) && 
            (!gameManagerScript.finishedTutorial) && 
            (gameManagerScript._matches == gameManagerScript.cards.Length/2))
        {
            animator.SetTrigger("OriginalCardState");
            sound.PlayOneShot(losing);
            gameManagerScript.playAnimationForFirstCard();
        }

    }

    /// <summary>
    /// disalbe cards when state is 1 ( faced up ) and enables it otherwise ( when state is 0 ) 
    /// </summary>
    public void disableAndEnableCard()
    {
        if (_state == 1)
            GetComponent<Button>().enabled = false;
        else
            GetComponent<Button>().enabled = true;
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