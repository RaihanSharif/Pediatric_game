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

        RadialProgressBar progressBarScript = GameObject.Find("RadialProgressBar").GetComponent<RadialProgressBar>();

        progressBarScript.setCurrentBarValue(10);
        yield return new WaitForSeconds(2);

        progressBarScript.setDecreaseBar(true);

        GameObject gameFinishMenu = GameObject.Find("LevelFinishedMenu");
        GameObject blurPanel = gameFinishMenu.transform.Find("BlurPanel").gameObject;

        if (blurPanel.activeSelf) {
            Assert.AreEqual(true, blurPanel.activeSelf);
        }
	}

    /// <summary>
    /// Check if the progress bar does not finish,
    /// the blur panel state should return a false
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator TestToPassIfFinishMenuNotDesplayedIfTimeStillRemaining()
    {
         LoadSceneByName("WaitingRoom");
         yield return null;

         RadialProgressBar progressBarScript = GameObject.Find("RadialProgressBar").GetComponent<RadialProgressBar>();

         yield return new WaitForSeconds(3);

         progressBarScript.setDecreaseBar(true);

        GameObject gameFinishMenu = GameObject.Find("LevelFinishedMenu");
        GameObject blurPanel = gameFinishMenu.transform.Find("BlurPanel").gameObject;
        bool blurPanelState = blurPanel.activeSelf;

        Assert.AreNotEqual(true, blurPanelState);
    }
}
