using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchingCardGameTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}


	//		var card1script = compare[0].GetComponent<Card>();
	//		var card2script = compare[1].GetComponent<Card>();
	//
	//		compare[0].GetComponent<Button>().onClick.Invoke();
	//		yield return new WaitForSeconds(1);
	//
	//		compare[1].GetComponent<Button>().onClick.Invoke();
	//		yield return new WaitForSeconds(1);


	//	var card1 = GameObject.Find("card 3"); 		// name of variable is card1 but name of game object is not as to not trigger the tutorial, so I just used "card 3"
	//	var card2 = GameObject.Find("card 2");
	//
	//	var card1script = card1.GetComponent<Card>();
	//	var card2script = card2.GetComponent<Card>();
	//
	//	card1script.cardValue = 1;
	//	card2script.cardValue = 1;
	//
	//	yield return null;
	//
	//	card1.GetComponent<Button>().onClick.Invoke();
	//	yield return new WaitForSeconds(1);
	//
	//	card2.GetComponent<Button>().onClick.Invoke();
	//	yield return new WaitForSeconds(1);


	//=================================== WHEN CARD VALUES ARE EQUAL =====================================\\


	/// <summary>
	/// Checks whether the first card stays up
	/// if it matches the second card.
	/// </summary>
	/// <returns>If card1's state is 1.</returns>
	[UnityTest]
	public IEnumerator ValuesMatchCard1StateIsUp(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreEqual(2, cards[indexes[0]].GetComponent<Card>().state);

	}

	/// <summary>
	/// Checks whether the second card stays up
	/// if it matches the first card.
	/// </summary>
	/// <returns>If card2's state is 1.</returns>
	[UnityTest]
	public IEnumerator ValuesMatchCard2StateIsUp(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreEqual(2, cards[indexes[1]].GetComponent<Card>().state);

	}

	/// <summary>
	/// Checks whether the first card is disabled
	/// if it matches the second card.
	/// </summary>
	/// <returns>If card1's enabled variable is false.</returns>
	[UnityTest]
	public IEnumerator ValuesMatchCard1IsDisabled(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreEqual(false, cards[indexes[0]].GetComponent<Button>().enabled);

	}

	/// <summary>
	/// Checks whether the second card is disabled
	/// if it matches the first card.
	/// </summary>
	/// <returns>If card2's enabled variable is false.</returns>
	[UnityTest]
	public IEnumerator ValuesMatchCard2IsDisabled(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreEqual(false, cards[indexes[1]].GetComponent<Button>().enabled);

	}

	/// <summary>
	/// Checks whether the variable with the number of matches left
	/// decrements when the two cards match.
	/// </summary>
	/// <returns>If the variable is equal to 7.</returns>
	[UnityTest]
	public IEnumerator CardsMatchCounterDecrements(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		var countToCompare = gmscript._matches;
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreEqual(countToCompare-1, gmscript._matches);

	}

	/// <summary>
	/// Checks whether the text that displays the number of matches left
	/// updates when the two cards match.
	/// </summary>
	/// <returns>If the variable is equal to 7.</returns>
	[UnityTest]
	public IEnumerator CardsMatchTextUpdates(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		var countToCompare = gmscript._matches;
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreEqual("Matches Left: " + (countToCompare-1).ToString(), gmscript.matchText.text);

	}


	//=================================== WHEN CARD VALUES ARE DIFFERENT =====================================\\


	/// <summary>
	/// Checks whether the first card goes back down
	/// if it doesn't match the second card.
	/// </summary>
	/// <returns>If card1's state is 0.</returns>
	[UnityTest]
	public IEnumerator ValuesDontMatchCard1StateIsDown(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indexes.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreNotEqual(2, cards[indexes[0]].GetComponent<Card>().state);

	}

	/// <summary>
	/// Checks whether the second card goes back down
	/// if it doesn't match the first card.
	/// </summary>
	/// <returns>If card2's state is 0.</returns>
	[UnityTest]
	public IEnumerator ValuesDontMatchCard2StateIsDown(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indexes.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreNotEqual(2, cards[indexes[1]].GetComponent<Card>().state);

	}

	/// <summary>
	/// Checks whether the first card is enabled
	/// if it doesn't match the second card.
	/// </summary>
	/// <returns>If card1's enabled variable is true.</returns>
	[UnityTest]
	public IEnumerator ValuesDontMatchCard1IsEnabled(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		gmscript.finishedTutorial = true;

		yield return null;

		var card1 = GameObject.Find("card 3");
		var card2 = GameObject.Find("card 2");

		var card1script = card1.GetComponent<Card>();
		var card2script = card2.GetComponent<Card>();

		card1script.cardValue = 1;
		card2script.cardValue = 2;

		card1.GetComponent<Button>().onClick.Invoke();
		yield return new WaitForSeconds(1);

		card2.GetComponent<Button>().onClick.Invoke();
		yield return new WaitForSeconds(1);

		Assert.AreEqual(true, card1.GetComponent<Button>().enabled);

	}

	/// <summary>
	/// Checks whether the second card is enabled
	/// if it doesn't match the first card.
	/// </summary>
	/// <returns>If card2's enabled variable is true.</returns>
	[UnityTest]
	public IEnumerator ValuesDontMatchCard2IsEnabled(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		gmscript.finishedTutorial = true;

		yield return null;

		var card1 = GameObject.Find("card 3");
		var card2 = GameObject.Find("card 2");

		var card1script = card1.GetComponent<Card>();
		var card2script = card2.GetComponent<Card>();

		card1script.cardValue = 1;
		card2script.cardValue = 2;

		card1.GetComponent<Button>().onClick.Invoke();
		yield return new WaitForSeconds(1);

		card2.GetComponent<Button>().onClick.Invoke();
		yield return new WaitForSeconds(1);

		Assert.AreEqual(true, card2.GetComponent<Button>().enabled);

	}

	/// <summary>
	/// Checks whether the variable with the number of matches left
	/// doesn't decrement when the two cards don't match.
	/// </summary>
	/// <returns>If the variable is still equal to 8.</returns>
	[UnityTest]
	public IEnumerator CardsDontMatchCounterDoesntDecrement(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		var countToCompare = gmscript._matches;
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indexes.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreNotEqual(countToCompare-1, gmscript._matches);

	}

	/// <summary>
	/// Checks whether the text that displays the number of matches left
	/// doesn't update when the two cards don't match.
	/// </summary>
	/// <returns>If the text is still the same after the comparison.</returns>
	[UnityTest]
	public IEnumerator CardsDontMatchTextDoesntUpdate(){

		LoadSceneByName("CardMatchingGame");
		yield return null;

		var gm = GameObject.Find("GameManager");
		var gmscript = gm.GetComponent<GameManager>();
		var countToCompare = gmscript._matches;
		gmscript.finishedTutorial = true;

		var cards = gmscript.cards;
		var indexes = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indexes.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indexes.Add(i);
		}

		gmscript.cardComparison(indexes);

		yield return new WaitForSeconds(1);

		Assert.AreNotEqual("Matches Left: " + (countToCompare-1).ToString(), gmscript.matchText.text);

	}

}
