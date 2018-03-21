using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;

    private bool _init = false;
    private int _matches = 6;

    public bool finishedTutorial;

    void Start()
    {
        cards[0].GetComponent<Animator>().SetTrigger("changeColourNEnlarge");
    }

    void Update()
    {
        if (!_init) { initializeCards(); }
        if (Input.GetMouseButtonUp(0))
            checkCards();
    }

    void initializeCards()
    {
        // every card has a match 
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 7 ; i++)
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

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    }

    void checkCards()
    {

        List<int> c = new List<int>();
        for (int i = 0; i < cards.Length; i++)
        {
            // going through the list and if 1 card up then add to list
            if (cards[i].GetComponent<Card>().state == 1)
                c.Add(i);
        }

        // if 2 cards up then compare the cards
        if (c.Count == 2)
            cardComparison(c);
    }

    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true;
        int x = 0;
        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            x = 2;
            _matches--;
            matchText.text = "Number of Matches: " + _matches;
            if (_matches == 0)
                SceneManager.LoadScene("SecondGameMenu");
        }
        for (int i = 0; i < c.Count; i++)
        { cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }

    public int indexForMatchingCard = 0;

    public int getIndexOfMatchingFirstCard(string cardSpriteName)
    {
        
        Debug.Log("passed value: " + cardSpriteName);

        foreach (GameObject card in cards)
        {
            indexForMatchingCard++;
            Debug.Log("card sprite name: " + card.GetComponent<Card>().getCardFace().name + " ,at index: " + indexForMatchingCard);
            if (card.GetComponent<Card>().getCardFace().name == cardSpriteName && indexForMatchingCard != 1)
            {
                break;
            }
        }

        Debug.Log("this is i : " + indexForMatchingCard);
        playAnimationForWrongMatch();
        return indexForMatchingCard;
    }

    public void playAnimationForCorrectgMatch()
    {
        cards[indexForMatchingCard-1].GetComponent<Animator>().SetTrigger("changeColourNEnlarge");
    }

    public void playAnimationForWrongMatch()
    {
        Debug.Log("^^^^^^^^^^^^^^^^^^^^^^  " + indexForMatchingCard + "  ^^^^^^^^^^^^^^^^^^^^");
        if (indexForMatchingCard > 0 && indexForMatchingCard < cards.Length)
        {
            cards[indexForMatchingCard].GetComponent<Animator>().SetTrigger("changeColourNEnlarge");
        }
        else if (indexForMatchingCard <= cards.Length)
        {
            cards[indexForMatchingCard + 1].GetComponent<Animator>().SetTrigger("changeColourNEnlarge");
        }
    }

}