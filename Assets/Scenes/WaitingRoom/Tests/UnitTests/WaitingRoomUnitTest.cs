using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaitingRoomUnitTest {

    private void LoadSceneByName(string name)
    {

        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    [Test]
	public void WaitingRoomUnitTestSimplePasses() {
		// Use the Assert class to test conditions.
	}
    
    /// <summary>
    /// Check if the finish menu bar apprears if the 
    /// progress bar value goes to 0 and the finished
    /// menu pops up
    /// </summary>
	[UnityTest]
	public IEnumerator TimeGaugeUnitTestToPassIfProgressBarValueGoesTo0AndDisplaysFinishMenu() {
        LoadSceneByName("WaitingRoom");
        yield return null;

        GameObject menu = GameObject.Find("LevelFinishedMenu");
        menu.SetActive(false);

        RadialProgressBar progressBarScript = GameObject.Find("RadialProgressBar").GetComponent<RadialProgressBar>();

        progressBarScript.setCurrentBarValue(10);
        //yield return new WaitForSeconds(3);

        //bool menuActiveState = GameObject.Find("LevelFinishedMenu").activeSelf;

        progressBarScript.setDecreaseBar(true);
        //yield return new WaitForSeconds(4);

        Assert.AreEqual(true, menu.activeSelf);
	}

    [UnityTest]
    public IEnumerator TestToPassIfFinishMenuNotDesplayedIfTimeStillRemaining()
    {
         LoadSceneByName("WaitingRoom");
         yield return null;

         GameObject menu = GameObject.Find("LevelFinishedMenu");
         menu.SetActive(false);

         RadialProgressBar progressBarScript = GameObject.Find("RadialProgressBar").GetComponent<RadialProgressBar>();

         yield return new WaitForSeconds(3);

         progressBarScript.setDecreaseBar(true);

         Assert.AreNotEqual(true, menu.activeSelf);
    }
}
