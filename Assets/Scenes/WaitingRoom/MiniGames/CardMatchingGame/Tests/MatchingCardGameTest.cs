﻿using UnityEngine;
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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indices.Add(i);
		}

		gmscript.cardComparison(indices);

		yield return new WaitForSeconds(1);

		Assert.AreEqual(2, cards[indices[0]].GetComponent<Card>().state);

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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indices.Add(i);
		}

		gmscript.cardComparison(indices);

		yield return new WaitForSeconds(1);

		Assert.AreEqual(2, cards[indices[1]].GetComponent<Card>().state);

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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indices.Add(i);
		}

		gmscript.cardComparison(indices);
		var isEnabled = cards[indices[0]].GetComponent<Button>().enabled;

		yield return new WaitForSeconds(1);

		Assert.AreNotEqual(true, isEnabled);

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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indices.Add(i);
		}

		gmscript.cardComparison(indices);
		var isEnabled = cards[indices[1]].GetComponent<Button>().enabled;

		yield return new WaitForSeconds(1);

		Assert.AreNotEqual(true, isEnabled);

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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indices.Add(i);
		}

		gmscript.cardComparison(indices);

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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (cards[i].GetComponent<Card>().cardValue == 1) indices.Add(i);
		}

		gmscript.cardComparison(indices);

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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indices.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indices.Add(i);
		}

		gmscript.cardComparison(indices);

		yield return new WaitForSeconds(1);

		Assert.AreNotEqual(2, cards[indices[0]].GetComponent<Card>().state);

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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indices.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indices.Add(i);
		}

		gmscript.cardComparison(indices);

		yield return new WaitForSeconds(1);

		Assert.AreNotEqual(2, cards[indices[1]].GetComponent<Card>().state);

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

		var cards = gmscript.cards;
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indices.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indices.Add(i);
		}

		gmscript.cardComparison(indices);
		var isEnabled = cards[indices[0]].GetComponent<Button>().enabled;

		yield return new WaitForSeconds(1);

		Assert.AreEqual(true, isEnabled);

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

		var cards = gmscript.cards;
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indices.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indices.Add(i);
		}

		gmscript.cardComparison(indices);
		var isEnabled = cards[indices[1]].GetComponent<Button>().enabled;

		yield return new WaitForSeconds(1);

		Assert.AreEqual(true, isEnabled);

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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indices.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indices.Add(i);
		}

		gmscript.cardComparison(indices);

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
		var indices = new List<int>();

		yield return null;

		for (int i = 0; i < cards.Length; i++){
			if (i == 0) indices.Add(i);
			else if (cards[i].GetComponent<Card>().cardValue != cards[0].GetComponent<Card>().cardValue) indices.Add(i);
		}

		gmscript.cardComparison(indices);

		yield return new WaitForSeconds(1);

		Assert.AreNotEqual("Matches Left: " + (countToCompare-1).ToString(), gmscript.matchText.text);

	}

}