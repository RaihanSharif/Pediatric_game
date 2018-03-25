using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // the list of the faces that are given for each card
    public Sprite[] cardFace;
    // the face back, this is not a list as all cards have the same back sprite
    public Sprite cardBack;
    public GameObject[] cards;
    // the text dispalyed in the bottom of the screen indicating the number of the matches that are left
    public Text matchText;

    // boolean flag that checks if cards are initialised or not
    private bool _init = false;
    // the number of matches left, 8 is assigned as there are 16 cards and there are 8 matches.
    public int _matches = 8;

    // checks if the tutorial is finished or not
    public bool finishedTutorial;

    // this gets index of the matching card for the first card
    public int indexForMatchingCard = 0;

    AudioSource sound;
    public AudioClip match;


    /// <summary>
    /// At the start of the game we want the animation for the first card to be displayed
    /// </summary>
    void Start()
    {
        cards[0].GetComponent<Animator>().SetTrigger("changeColourNEnlarge");
        sound = GetComponent<AudioSource>();
        disableAllCards();
    }

    void disableAllCards()
    {
        foreach (GameObject card in cards)
        {
            if (card.GetComponent<Card>().name != "card 1")
                card.GetComponent<Button>().interactable = false;
        }
    }

    void enableAllCards()
    {
        foreach (GameObject card in cards)
        {
            card.GetComponent<Button>().interactable = true;

        }
    }


    /// <summary>
    /// this checks if the cards are intialised or not 
    /// when the mouse is clicked then call the function checkCards
    /// </summary>
    void Update()
    {
        if (!_init) { initializeCards(); }
        if (Input.GetMouseButtonUp(0))
            checkCards();
        if (_matches != cards.Length / 2)
            stopAllAnimations();
        if (finishedTutorial)
            enableAllCards();
    }

    void stopAllAnimations()
    {
        foreach (GameObject card in cards)
        {
            card.GetComponent<Animator>().Play("Idle");
        }
    }

    /// <summary>
    /// This initialises the cards so that for each card there is a matching. 
    /// </summary>
    void initializeCards()
    {
        // every card has a match 
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 9; i++)
            {
                bool test = false;
                int choice = 0;
                // tests if cards is initialised 
                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized);
                }
                // it initialises it 
                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().initialized = true;
            }
        }

        foreach (GameObject c in cards)
            c.GetComponent<Card>().setupGraphics();
        if (!_init) _init = true;
    }

    /// <summary>
    /// returns the sprite for the card back    
    /// </summary>
    /// <returns></returns>
    public Sprite getCardBack()
    {
        return cardBack;
    }

    /// <summary>
    /// gets the index of the card that we want to get the face up and returns it.
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    }

    /// <summary>
    /// Checks if there is a match or not. 
    /// </summary>
    void checkCards()
    {

        List<int> c = new List<int>();
        // going through each card in the cards list 
        for (int i = 0; i < cards.Length; i++)
        {
            // and if the state is 1 ( card up ) then add to list
            if (cards[i].GetComponent<Card>().state == 1)
                c.Add(i);
        }

        // if 2 cards up then compare the cards
        if (c.Count == 2)
            cardComparison(c);
    }

    /// <summary>
    /// compares if the cards that faces up have the same value or not. it takes a parameter c which is being passed from checkCards function 
    /// </summary>
    /// <param name="c"></param>
    void cardComparison(List<int> c)
    {
        // this halt the game for few fractions of the second while the comparision takes place 
        Card.DO_NOT = true;
        int x = 0;
        // from the list c in checkCards check if the value of the first card is the same as the value of the second card
        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            // if there is a match then disable the two matched cards
            cards[c[0]].GetComponent<Button>().enabled = false;
            cards[c[1]].GetComponent<Button>().enabled = false;
            x = 2;
            _matches--;
            matchText.text = "Number of Matches: " + _matches;
            sound.PlayOneShot(match);
            // if the number of matches is 0 then go to the menu scene 
            if (_matches == 0)
                SceneManager.LoadScene("SecondGameMenu");

        }


        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }


    // gets the cardSpriteName for the first card then it goes through each card to check which card has the same sprite 
    public int getIndexOfMatchingFirstCard(string cardSpriteName)
    {

        foreach (GameObject card in cards)
        {
            indexForMatchingCard++;
            if (card.GetComponent<Card>().getCardFace().name == cardSpriteName && indexForMatchingCard != 1)
            {
                break;
            }
        }

        return indexForMatchingCard;
    }

    /// <summary>
    /// plays the animation for the wrong matching card ( which is always one after the right matching card ) 
    /// </summary>
    public void playAnimationForCorrectgMatch()
    {
        cards[indexForMatchingCard - 1].GetComponent<Animator>().SetTrigger("changeColourNEnlarge");
    }

    /// <summary>
    /// plays the enlarge and the changing colour to yellow for the first card
    /// </summary>
    public void playAnimationForFirstCard()
    {
        cards[0].GetComponent<Animator>().SetTrigger("changeColourNEnlarge");
    }

    /// <summary>
    /// play animation for the wrong match
    /// </summary>
    public void playAnimationForWrongMatch()
    {
        // checks if the match is the last card then the worng matching card will not be one after it but rather it will be 1 before it 
        if (indexForMatchingCard == cards.Length - 1 || indexForMatchingCard == cards.Length + 1 || indexForMatchingCard == cards.Length)
        {
            cards[indexForMatchingCard - 2].GetComponent<Animator>().SetTrigger("changeColourNEnlarge");
            cards[indexForMatchingCard - 2].GetComponent<Button>().interactable = true;
        }
        // else the wrong matching card will be the one after the right matching card
        else
        {
            cards[indexForMatchingCard].GetComponent<Animator>().SetTrigger("changeColourNEnlarge");
            cards[indexForMatchingCard].GetComponent<Button>().interactable = true;
        }

    }


}