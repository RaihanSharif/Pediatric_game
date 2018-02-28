using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ArmTesting {

	//	[Test]
	//	public void ArmTestingSimplePasses() {
	//		// Use the Assert class to test conditions.
	//	}

	/// <summary>
	/// Make an object of the Arm class by using the AddComponent from
	/// the Game Object class, then call startProcess() method and check
	/// whether it has correctly incremented the CreamCurrentProgress
	/// </summary>
	[UnityTest]
	public IEnumerator CreamIncrementsWellReturnsTrue() {

		var arm = new GameObject ().AddComponent<Arm> ();
		arm.CreamCurrentProgress = 0f;
		arm.CreamMaxProgress = 6f;
		arm.ProgressOffset = 3;
		arm.startProcess ();
		yield return null;

		Assert.AreEqual (arm.CreamCurrentProgress, 3);

	}

	/// <summary>
	/// Make an object of the Arm class by using the AddComponent
	/// from the Game Object class, then call startProcess() method
	/// 4 times, then check whether the value of CreamCurrentProgress
	/// corresponds to the value of CreamMaxProgress
	/// </summary>
	[UnityTest]
	public IEnumerator CreamGoesToMaxValueReturnsTrue() {

		var arm = new GameObject ().AddComponent<Arm> ();
		arm.CreamCurrentProgress = 0f;
		arm.CreamMaxProgress = 6f;
		arm.ProgressOffset = 3;
		arm.startProcess ();
		arm.startProcess ();
		yield return null;

		Assert.AreEqual (arm.CreamCurrentProgress, arm.CreamMaxProgress);
	}
}

