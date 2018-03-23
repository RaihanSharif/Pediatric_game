using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngBabyUnitTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	/// <summary>
	/// Clicks on the first bubble and checks whether it has 
	/// changed the firstPopped variable to true in the script
	/// </summary>
	/// <returns>The baby unit test with enumerator passes.</returns>
	[UnityTest]
	public IEnumerator A_FirstBubblePoppedPasses() {
		LoadSceneByName ("IngestionBaby");
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();

		Assert.AreEqual (bubble.getFirstPopped (), true);

	}

	/// <summary>
	/// Clicks on the first, second and third bubble and 
	/// checks whether they have all been clicked
	/// </summary>
	/// <returns>The baby unit test with enumerator passes.</returns>
	[UnityTest]
	public IEnumerator B_ThreeFirstBubblesPoppedPasses() {
		LoadSceneByName ("IngestionBaby");
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (3);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (3);
		otherBubble.OnMouseDown ();

		Assert.AreEqual (otherBubble.bubbleNum-1, 3);
	}

}
