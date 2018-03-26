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
		yield return new WaitForSeconds (10);
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


    [UnityTest]
    public IEnumerator PositionOfStrap1()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        findScene("CameraRoom");
        yield return null;
        var strap1 = GameObject.FindGameObjectWithTag(tags[0]);
        strap1.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[0]));
        strap1.transform.position = new Vector2(-4, 0.2f);
        yield return null;
        yield return new WaitForSeconds(1);
        var testingScript = strap1.GetComponent<DragAndDropCameraRoom>();
        testingScript.setSandbag1(true);
        testingScript.setSandbag2(true);
        testingScript.clickIntoPlace();
        yield return new WaitForSeconds(1);
        var testStrap1 = strap1.GetComponent<DragAndDropCameraRoom>().getstrap1inPlace();
        Assert.AreEqual(testStrap1, true);

    }

    [UnityTest]
    public IEnumerator PositionOfStrap2()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        findScene("CameraRoom");
        yield return null;
        var strap2 = GameObject.FindGameObjectWithTag(tags[1]);
        strap2.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[1]));
        strap2.transform.position = new Vector2(0f, 0.2f);
        yield return null;
        yield return new WaitForSeconds(1);
        var testingScript = strap2.GetComponent<DragAndDropCameraRoom>();
        testingScript.setSandbag1(true);
        testingScript.setSandbag2(true);
        testingScript.clickIntoPlace();
        yield return new WaitForSeconds(1);
        var testStrap2 = strap2.GetComponent<DragAndDropCameraRoom>().getstrap2inPlace();
        Assert.AreEqual(testStrap2, true);

    }

    [UnityTest]
    public IEnumerator PositionOfCameraTop()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        findScene("CameraRoom");
        yield return null;
        var cameraTop = GameObject.FindGameObjectWithTag(tags[5]);
        cameraTop.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[5]));
        cameraTop.transform.position = new Vector2(6.3f, 0f);
        yield return null;
        yield return new WaitForSeconds(1);
        var testingScript = cameraTop.GetComponent<DragAndDropCameraRoom>();
        testingScript.setSandbag1(true);
        testingScript.setSandbag2(true);
        testingScript.setStrap1(true);
        testingScript.setStrap2(true);
        testingScript.clickIntoPlace();
        yield return new WaitForSeconds(1);
        var testCameraTop = cameraTop.GetComponent<DragAndDropCameraRoom>().getcamera1inPlace();
        Assert.AreEqual(testCameraTop, true);

    }

    [UnityTest]
    public IEnumerator PositionOfCameraBottom()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        findScene("CameraRoom");
        yield return null;
        var cameraBottom = GameObject.FindGameObjectWithTag(tags[6]);
        cameraBottom.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[6]));
        cameraBottom.transform.position = new Vector2(6.3f, 0f);
        yield return null;
        yield return new WaitForSeconds(1);
        var testingScript = cameraBottom.GetComponent<DragAndDropCameraRoom>();
        testingScript.setSandbag1(true);
        testingScript.setSandbag2(true);
        testingScript.setStrap1(true);
        testingScript.setStrap2(true);
        testingScript.clickIntoPlace();
        yield return new WaitForSeconds(1);
        var testCameraBottom = cameraBottom.GetComponent<DragAndDropCameraRoom>().getcamera2inPlace();
        Assert.AreEqual(testCameraBottom, true);

    }

    [UnityTest]
    public IEnumerator PositionOfTable()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        findScene("CameraRoom");
        yield return null;
        var table = GameObject.FindGameObjectWithTag(tags[4]);
        table.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[4]));
        table.transform.position = new Vector2(1.75f, 0f);
        yield return null;
        yield return new WaitForSeconds(1);
        var testingScript = table.GetComponent<DragAndDropCameraRoom>();
        testingScript.clickIntoPlace();
        yield return new WaitForSeconds(1);
        var testTable = table.GetComponent<DragAndDropCameraRoom>().gettableInPLace();
        Assert.AreEqual(testTable, true);

    }

}
