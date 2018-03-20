using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraRoomUnitTests
{

    private string[] tags = { "Strap1", "Strap2", "Sandbag1", "Sandbag2", "Table", "CameraTop", "CameraBottom" };

    private void findScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    [Test]
    public void CameraRoomUnitTestsSimplePasses()
    {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator PositionOfSandbag1()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        findScene("CameraRoom");
        yield return null;
        var sandbag1 = GameObject.FindGameObjectWithTag(tags[2]);
        sandbag1.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[2]));
        sandbag1.transform.position = new Vector2(-2f, -2f);
        yield return null;
        yield return new WaitForSeconds(1);
        var testingScript = sandbag1.GetComponent<DragAndDropCameraRoom>();
        testingScript.clickIntoPlace();
        yield return new WaitForSeconds(1);
        var testSandbag1 = sandbag1.GetComponent<DragAndDropCameraRoom>().getsandbag1inPlace();
        Assert.AreEqual(testSandbag1, true);

    }
    [UnityTest]
    public IEnumerator PositionOfSandbag2()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        findScene("CameraRoom");
        yield return null;
        var sandbag2 = GameObject.FindGameObjectWithTag(tags[3]);
        sandbag2.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[3]));
        sandbag2.transform.position = new Vector2(-2f, 2f);
        yield return null;
        yield return new WaitForSeconds(1);
        var testingScript = sandbag2.GetComponent<DragAndDropCameraRoom>();
        testingScript.clickIntoPlace();
        yield return new WaitForSeconds(1);
        var testSandbag2 = sandbag2.GetComponent<DragAndDropCameraRoom>().getsandbag2inPlace();
        Assert.AreEqual(testSandbag2, true);

    }

}
