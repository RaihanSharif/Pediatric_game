using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngBabyUnitTest {

	private void LoadBabyIngestionScene() {
		SceneManager.LoadScene("IngestionBaby", LoadSceneMode.Single);
	}

	/// <summary>
	/// Clicks on the first bubble and checks whether it has 
	/// changed the firstPopped variable to true in the script
	/// </summary>
	[UnityTest]
	public IEnumerator A_FirstBubblePoppedPasses() {
		LoadBabyIngestionScene ();
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();

		Assert.AreEqual (bubble.getFirstPopped(), true);

	}

	/// <summary>
	/// Clicks on the first, second and third bubble and 
	/// checks whether they have all been clicked
	/// </summary>
	[UnityTest]
	public IEnumerator B_ThreeFirstBubblesPoppedPasses() {
		LoadBabyIngestionScene ();
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


	/// <summary>
	/// Click the three first bubbles then wait for the second blue
	/// bubble to appear, click it and check it has been clicked
	/// </summary>
	[UnityTest]
	public IEnumerator C_SecondBlueBubblePoppedPasses() {
		LoadBabyIngestionScene ();
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (1);

		var secondBlue = GameObject.Find ("BlueBubble2").GetComponent<BubbleClick> ();
		secondBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		Assert.AreEqual (secondBlue.bubbleNum, 2);
	}

	/// <summary>
	/// Click the three first bubbles then wait for the second and third blue
	/// bubbles to appear, click them and check that they have been clicked
	/// </summary>
	[UnityTest]
	public IEnumerator D_ThirdBlueBubblePoppedPasses() {
		LoadBabyIngestionScene ();
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (1);

		var secondBlue = GameObject.Find ("BlueBubble2").GetComponent<BubbleClick> ();
		secondBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdBlue = GameObject.Find ("BlueBubble3").GetComponent<BubbleClick> ();
		thirdBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		Assert.AreEqual (thirdBlue.bubbleNum, 3);
	}


	/// <summary>
	/// Click the five first bubbles, then click on the first
	/// pink moving bubble and check that it has been clicked
	/// </summary>
	[UnityTest]
	public IEnumerator E_SecondPinkBubblePoppedPasses() {
		LoadBabyIngestionScene ();
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (1);

		var secondBlue = GameObject.Find ("BlueBubble2").GetComponent<BubbleClick> ();
		secondBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdBlue = GameObject.Find ("BlueBubble3").GetComponent<BubbleClick> ();
		thirdBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var secondPurple = GameObject.Find ("PinkBubble2").GetComponent<BubbleClick> ();
		secondPurple.OnMouseDown ();
		secondPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		Assert.AreEqual (secondPurple.bubbleNum, 5);

	}

	/// <summary>
	/// Click the five first bubbles, then click on the first and second
	/// pink moving bubbles and check that they have been clicked
	/// </summary>
	[UnityTest]
	public IEnumerator F_ThirdPinkBubblePoppedPasses() {
		LoadBabyIngestionScene ();
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (1);

		var secondBlue = GameObject.Find ("BlueBubble2").GetComponent<BubbleClick> ();
		secondBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdBlue = GameObject.Find ("BlueBubble3").GetComponent<BubbleClick> ();
		thirdBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var secondPurple = GameObject.Find ("PinkBubble2").GetComponent<BubbleClick> ();
		secondPurple.OnMouseDown ();
		secondPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdPurple = GameObject.Find ("PinkBubble3").GetComponent<BubbleClick> ();
		thirdPurple.OnMouseDown ();
		thirdPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		Assert.AreEqual (thirdPurple.bubbleNum, 6);

	}

	/// <summary>
	/// Click past all the bubbles, then click once on the baby bottle
	/// and check that the volume inside the bottle has diminished
	/// </summary>
	[UnityTest]
	public IEnumerator G_BottleDiminshesVolumePasses() {
		LoadBabyIngestionScene ();
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (1);

		var secondBlue = GameObject.Find ("BlueBubble2").GetComponent<BubbleClick> ();
		secondBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdBlue = GameObject.Find ("BlueBubble3").GetComponent<BubbleClick> ();
		thirdBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var secondPurple = GameObject.Find ("PinkBubble2").GetComponent<BubbleClick> ();
		secondPurple.OnMouseDown ();
		secondPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdPurple = GameObject.Find ("PinkBubble3").GetComponent<BubbleClick> ();
		thirdPurple.OnMouseDown ();
		thirdPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var bottle = GameObject.Find ("babyBottle").GetComponent<playAnimationOnClick> ();
		bottle.OnMouseDown ();
		var anim = GameObject.Find ("babyBottle").GetComponent<Animator> ();
		anim.Play ("BabyBottleAnim");
		var bottleScript = GameObject.Find ("babyBottle").GetComponent<Babybottle> ();
		bottleScript.OnMouseDown ();
		yield return null;
		yield return new WaitForSeconds (0.5f);

		Assert.AreEqual (1, bottleScript.ctr);

	}

	/// <summary>
	/// Click past all the bubbles, then click three times on the baby bottle
	/// and check that the volume inside the bottle has diminished by half
	/// </summary>
	[UnityTest]
	public IEnumerator H_BottleDiminshesByHalfPasses() {
		LoadBabyIngestionScene ();
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (1);

		var secondBlue = GameObject.Find ("BlueBubble2").GetComponent<BubbleClick> ();
		secondBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdBlue = GameObject.Find ("BlueBubble3").GetComponent<BubbleClick> ();
		thirdBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var secondPurple = GameObject.Find ("PinkBubble2").GetComponent<BubbleClick> ();
		secondPurple.OnMouseDown ();
		secondPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdPurple = GameObject.Find ("PinkBubble3").GetComponent<BubbleClick> ();
		thirdPurple.OnMouseDown ();
		thirdPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var bottle = GameObject.Find ("babyBottle").GetComponent<playAnimationOnClick> ();
		bottle.OnMouseDown ();
		var anim = GameObject.Find ("babyBottle").GetComponent<Animator> ();
		anim.Play ("BabyBottleAnim");
		var bottleScript = GameObject.Find ("babyBottle").GetComponent<Babybottle> ();
		bottleScript.OnMouseDown ();
		yield return null;
		yield return new WaitForSeconds (0.4f);

		for (int i = 0; i < 2; i++) {
			bottle.OnMouseDown ();
			anim.Play ("BabyBottleAnim");
			bottleScript.OnMouseDown ();
			yield return null;
			yield return new WaitForSeconds (0.4f);
		}

		Assert.AreEqual (3, bottleScript.ctr);

	}

	/// <summary>
	/// Click past all the bubbles, then click six times on
	/// the baby bottleand check that the bottle is now empty
	/// </summary>
	[UnityTest]
	public IEnumerator I_BottleEmptiedPasses() {
		LoadBabyIngestionScene ();
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (1);

		var secondBlue = GameObject.Find ("BlueBubble2").GetComponent<BubbleClick> ();
		secondBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdBlue = GameObject.Find ("BlueBubble3").GetComponent<BubbleClick> ();
		thirdBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var secondPurple = GameObject.Find ("PinkBubble2").GetComponent<BubbleClick> ();
		secondPurple.OnMouseDown ();
		secondPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdPurple = GameObject.Find ("PinkBubble3").GetComponent<BubbleClick> ();
		thirdPurple.OnMouseDown ();
		thirdPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var bottle = GameObject.Find ("babyBottle").GetComponent<playAnimationOnClick> ();
		bottle.OnMouseDown ();
		var anim = GameObject.Find ("babyBottle").GetComponent<Animator> ();
		anim.Play ("BabyBottleAnim");
		var bottleScript = GameObject.Find ("babyBottle").GetComponent<Babybottle> ();
		bottleScript.OnMouseDown ();
		yield return null;
		yield return new WaitForSeconds (0.4f);

		for (int i = 0; i < 5; i++) {
			bottle.OnMouseDown ();
			anim.Play ("BabyBottleAnim");
			bottleScript.OnMouseDown ();
			yield return null;
			yield return new WaitForSeconds (0.4f);
		}

		Assert.AreEqual (true, bottleScript.gameWon);

	}

}
