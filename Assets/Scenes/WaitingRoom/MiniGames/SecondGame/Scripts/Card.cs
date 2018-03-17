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

    void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
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

        if (_state == 0)
            _state = 1;
        else if (_state == 1)
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
}