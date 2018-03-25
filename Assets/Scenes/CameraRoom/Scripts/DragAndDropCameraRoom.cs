
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropCameraRoom : MonoBehaviour
{
    private bool strap1inPlace = false;
    private bool strap2inPlace = false;
    private bool sandbag1inPlace = false;
    private bool sandbag2inPlace = false;
    private bool camera1inPlace = false;
    private bool camera2inPlace = false;
    private bool tableInPLace = false;
    private bool zoomToLevel2 = false;
    private bool inLevel2 = false;
    private bool levelOver = false;
    private bool currentlyScanning = false;
    private bool draggingItem = false; //whether the player is currently dragging an item
    private GameObject draggedObject;  //holds a reference to an object being dragged
    private Vector2 touchOffset;  // allows a grabbed object to stick realistically to the player’s touch position (more about this later).
    private string[] tags = { "Strap1", "Strap2", "Sandbag1", "Sandbag2", "Table", "CameraTop", "CameraBottom" };

    private int score = 0;
    private float elapsed = 0.0f;

    public SpriteRenderer tableArrow;

    [SerializeField]
    private LevelFinishedMenu lvlFM;

    /// <summary>
    /// Start is called at the beginning of a scene.
    /// This is used to change the colour of the target
    /// and guidance objects at the start.
    /// Also initialises the guidance.
    /// </summary>
    void Start()
    {
        makeTargetRed();
        makeGuidanceObjectsTransparent();
        setGuidance("Sandbag");
    }

    /// <summary>
    /// Makes the target red; used to set the target's
    /// colour at the start of the game.
    /// </summary>
    void makeTargetRed()
    {
        GameObject.FindGameObjectWithTag("Target").GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
    }

    /// <summary>
    /// Makes the guidance objects partially see-through by
    /// iterating through all objects with the tag 'Guidance' and
    /// changing their Alpha values.
    /// </summary>
    void makeGuidanceObjectsTransparent()
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Guidance"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
    }

    /// <summary>
    /// Update runs each frame.
    /// Calls the methods DropItems() and DragOrPickup() when required.
    /// Checks if the player is currently touching the screen and, 
    /// if so, drags or picks up the object; 
    /// otherwise, drop the object that was being moved.
    /// </summary>
    void Update()
    {
        //Check for input and move objects if there is input.
        if (HasInput)
        {
            DragOrPickUp();
        }
        else    //Drop items if input is witdrawn and something was being dragged.
        {
            if (draggingItem)
            {
                DropItem();
            }
        }

        //If the boolean for zooming to the second half of the level is true, zoom the camera.
        if (zoomToLevel2)
        {
            disableHitbox("Table");
            cameraZoom();
        }

        //If the player has scanned the target and won the game, end the level.
        if (score >= 160 && !levelOver)
        {
            levelCleared();
        }
    }

    /// <summary>
    /// FixedUpdate after a set amount of time in the real world.
    /// Checks if the camera is over the target,
    /// and changes the target's colour and the score variable
    /// if so. FixedUpdate is used so that score and colour change
    /// happen at a predictable rate.
    /// </summary>
    void FixedUpdate()
    {
        if (inLevel2)
        {
            cameraOverTarget();
        }
    }

    /// <summary>
    /// Check whether the camera is over the target,
    /// and change the target's colour if so.
    /// Also increment the score.
    /// </summary>
    void cameraOverTarget()
    {
        //If the camera is in a region that sees the target...
        float x = GameObject.FindGameObjectWithTag("CameraTop").transform.position.x;
        if (x <= 1.5 && x >= 0.2)
        {
            score++;    //...increment the score...
            float targetR = GameObject.FindGameObjectWithTag("Target").GetComponent<SpriteRenderer>().color.r;
            float targetG = GameObject.FindGameObjectWithTag("Target").GetComponent<SpriteRenderer>().color.g;
            if (targetR <= 1 && targetG < 1 && targetR > 0 && targetG >= 0)
            {
                //...and fade the target from red towards green.

                GameObject.FindGameObjectWithTag("Target").GetComponent<SpriteRenderer>().color = new Color(targetR - 0.0005f, targetG + 0.0005f, 0, 1);
            }
        }
    }

    /// <summary>
    /// Zooms the camera smoothly to the position required in the second level.
    /// </summary>
    private void cameraZoom()
    {
        disableHitbox("Table");
        elapsed += Time.deltaTime;  //Keep track of the time elapsed during the zoom, using it to smoothly move the items.
        Camera.main.orthographicSize = Mathf.SmoothStep(5f, 3.5f, elapsed);     //Zoom the camera smoothly
        Camera.main.transform.position = new Vector3(Mathf.SmoothStep(0f, 2.1f, elapsed), 0f, -10f);    //Move the camera smoothly to the desired position.
        GameObject.FindGameObjectWithTag("CameraTop").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(1f, 0f, elapsed));  //Make the top camera fade out.

        //If the zoom process has completed, change boolean values and reset elapsed.
        if (elapsed > 1.0f)
        {
            zoomToLevel2 = false;
            inLevel2 = true;
            elapsed = 0f;
        }
    }

    /// <summary>
    /// If an item is being dragged, move it with the input; 
    /// if an object is not being dragged, 
    /// pick up an object that’s being touched.
    /// </summary>
    private void DragOrPickUp()
    {
        //Keep track of the posistion that input is being recieved.
        var inputPosition = CurrentTouchPosition;

        //If there is an item being moved, change its position to the input position and click the object into place if necessary.
        //TouchOffset is used to ensure that if the object is clicked at a specific position of its hitbox, move oriented to that position.
        if (draggingItem)
        {
            draggedObject.transform.position = inputPosition + touchOffset;
            clickIntoPlace();
        }
        else    //Otherwise, check boolean values to see the state of the level and enable hitboxes as necessary to move along the game.
        {
            if (sandbag1inPlace && sandbag2inPlace && strap1inPlace && strap2inPlace && !camera1inPlace && !camera2inPlace)
            {
                //When the sandbags and straps are in place, allow the cameras to move.
                enableHitbox("CameraTop");
                enableHitbox("CameraBottom");
            }
            if (camera1inPlace && camera2inPlace && !tableInPLace && !zoomToLevel2)
            {
                //When the cameras are in place, allow the table to move.
                enableHitbox("Table");
                //make table arrow visible 
                tableArrow.enabled = true;
            }
            if (inLevel2)
            {
                //make table arrow invisible
                tableArrow.enabled = false;
                disableHitbox("Table");

                //When the table is in place, allow the top camera to move.
                if (currentlyScanning)
                {
                    disableHitbox("CameraTop");
                }
                else
                {
                    enableHitbox("CameraTop");
                }

            }

            //Perform a raycast at at the input position.
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                //If the raycast hit something, pick it up.
                var hit = touches[0];
                PickUp(tags, hit, inputPosition);
            }
        }
    }

    /// <summary>
    /// Returns the position of a detected touch/mouse input.
    /// </summary>
    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    /// <summary>
    /// Disables the hitbox of an object with a given name.
    /// </summary>
    void disableHitbox(string name)
    {
        GameObject.FindGameObjectWithTag(name).GetComponent<BoxCollider2D>().enabled = false;
    }

    /// <summary>
    /// Enables the hitbox of an object with a given name.
    /// </summary>
    void enableHitbox(string name)
    {
        GameObject.FindGameObjectWithTag(name).GetComponent<BoxCollider2D>().enabled = true;
    }

    /// <summary>
    /// Drop an item that is being dragged, place it at (x, y), 
    /// and disable its box collider component.
    /// </summary>
    void disableDragableItem(float x, float y)
    {
        DropItem();
        draggedObject.transform.position = new Vector2(x, y);
        draggedObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    /// <summary>
    /// Releases a picked up item.
    /// </summary>
    void DropItem()
    {
        draggingItem = false;
    }

    /// <summary>
    /// Ensures that objects move as desired, including
    /// snapping them into place when they reach
    /// their destination and moving along a certain
    /// axis if necessary. Also edits boolean values to
    /// keep track of how far along the game is.
    /// </summary>
    public void clickIntoPlace()
    {
        //If dragging the table...
        if (draggedObject.name.Equals("Table"))
        {
            //...move the table to the mouse (or touch input) position .

            
                draggedObject.transform.position = new Vector2(draggedObject.transform.position.x, 0.0f);
           
           

            //If the table reaches the necessary position...
            if (draggedObject.transform.position.x > 1.5f && draggedObject.transform.position.x < 2.0f)
            {
                //... move it to exactly (2.1, 0) and disable its hitbox.
                disableDragableItem(2.1f, 0.0f);
                
                //draggedObject.transform.position = new Vector2(2.1f, 0.0f);
                disableHitbox("Table");
                tableInPLace = true;
                zoomToLevel2 = true;
            }
        }
        else if     //If Strap1 is in place and the sandbags are already in place, snap it into position.
            (draggedObject.name.Equals("Strap1") &&
            draggedObject.transform.position.y < 0.5f && draggedObject.transform.position.y > -0.5f
            && draggedObject.transform.position.x < -3.5f && draggedObject.transform.position.x > -4.5f
            && sandbag1inPlace && sandbag2inPlace)
        {
            disableDragableItem(-4.0f, 0.0f);
            strap1inPlace = true;
            draggedObject.transform.parent = GameObject.FindWithTag("Table").transform;
        }
        else if     //If Strap2 is in place and the sandbags are already in place, snap it into position.
            (draggedObject.name.Equals("Strap2") &&
            draggedObject.transform.position.y < 0.5f && draggedObject.transform.position.y > -0.5f
            && draggedObject.transform.position.x < 0.5f && draggedObject.transform.position.x > -0.5f
            && sandbag1inPlace && sandbag2inPlace)
        {
            disableDragableItem(0.0f, 0.0f);
            strap2inPlace = true;
            draggedObject.transform.parent = GameObject.FindWithTag("Table").transform;
        }
        else if     //If Sandbag1 is in place, snap it into position.
            (draggedObject.name.Equals("Sandbag1") &&
            draggedObject.transform.position.y < -1.15f && draggedObject.transform.position.y > -2.15f
            && draggedObject.transform.position.x < -1.5f && draggedObject.transform.position.x > -2.5f)
        {
            disableDragableItem(-2.0f, -1.65f);
            sandbag1inPlace = true;
            draggedObject.transform.parent = GameObject.FindWithTag("Table").transform;
        }
        else if     //If Sandbag2 is in place, snap it into position.
           (draggedObject.name.Equals("Sandbag2") &&
           draggedObject.transform.position.y > 1.15f && draggedObject.transform.position.y < 2.15f
           && draggedObject.transform.position.x < -1.5f && draggedObject.transform.position.x > -2.5f)
        {
            disableDragableItem(-2.0f, 1.65f);
            sandbag2inPlace = true;
            draggedObject.transform.parent = GameObject.FindWithTag("Table").transform;

        }
        else if     //If the top camera is being moved and both the sandbags and straps are in place...
            (draggedObject.name.Equals("CameraTop") && sandbag1inPlace && sandbag2inPlace && strap1inPlace && strap2inPlace)
        {
            //...and if still in the first half of the level, move the camera along the y axis until it snaps into place...
            if (!inLevel2)
            {
                draggedObject.transform.position = new Vector2(6.3f, draggedObject.transform.position.y);
                if (draggedObject.transform.position.y > -0.5f && draggedObject.transform.position.y < 0.5f)
                {
                    disableDragableItem(6.3f, 0f);
                    disableHitbox("CameraTop");
                    camera1inPlace = true;
                }
            }
            else    //...else if in the second half of the level, move the camera along the x axis.
            {
                if (draggedObject.transform.position.x > -2 && draggedObject.transform.position.x< 1)
                {
                    Debug.Log("Test1");
                    currentlyScanning = true;
                    disableDragableItem(1f, 0f);
                    disableHitbox("CameraTop");
                    //draggedObject.transform.position = new Vector2(1f, 0f);

                }
                else
                {
                    draggedObject.transform.position = new Vector2(draggedObject.transform.position.x, 0f);
                }
            }
        }
        else if     //If the bottom camera is being moved and both the sandbags and straps are in place...
            (draggedObject.name.Equals("CameraBottom") && sandbag1inPlace && sandbag2inPlace && strap1inPlace && strap2inPlace)
        {
            //...slide it along the Y axis until it snaps into place.
            draggedObject.transform.position = new Vector2(6.3f, draggedObject.transform.position.y);
            if (draggedObject.transform.position.y > -0.5f && draggedObject.transform.position.y < 0.5f)
            {
                disableDragableItem(6.3f, 0f);
                camera2inPlace = true;
                disableHitbox("CameraBottom");
            }
        }

        //Checks which stage the game is in and activates the necessary guidance using setGuidance.
        if (!sandbag1inPlace || !sandbag2inPlace)
        {
            setGuidance("Sandbag");
        }
        else if (!strap1inPlace || !strap2inPlace)
        {
            setGuidance("Strap");
        }
        else if (!camera1inPlace || !camera2inPlace)
        {
            setGuidance("Camera");
        }
        else if (!tableInPLace)
        {
            setGuidance("Table");
        }
        else
        {
            setGuidance("Scan");
        }
    }

    /// <summary>
    /// A method used to activate the SpriteRenderer component
    /// on certain guidance objects, and deactivate all other
    /// guidance objects' SpriteRenderers. Used to make only
    /// certain guidance objects visible.
    /// </summary>
    void setGuidance(string contents)
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Guidance"))
        {
            if (gameObject.name.Contains(contents))
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    /// <summary>
    /// Method used to iterate through all the 
    /// named & tagged items in the array 'tags', 
    /// and check if the raycast has hit them.
    /// </summary>
    void PickUp(string[] tags, RaycastHit2D hit, Vector2 inputPosition)
    {
        //If the raycast has hit something...
        if (hit.transform != null)
        {
            foreach (string tag in tags)
            {
                //...and the object that was hit matches one of the tagged objects...
                if (hit.collider.name.Equals(tag))
                {
                    draggedObject = GameObject.FindGameObjectWithTag(tag);  //...grab the object...
                    draggingItem = true;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;  //...while keeping track of where the user clicked on the object.
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Returns true when the player is currently
    /// touching the screen/holding the mouse button.
    /// </summary>
    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }

    /// <summary>
    /// Setters for booleans, for testing purposes.
    /// </summary>
    #region
    public void setDraggedObject(GameObject draggedComponent)
    {
        draggedObject = draggedComponent;
    }

    public void setSandbag1(bool setBool)
    {
        sandbag1inPlace = setBool;
    }

    public void setSandbag2(bool setBool)
    {
        sandbag2inPlace = setBool;
    }

    public void setStrap1(bool setBool)
    {
        strap1inPlace = setBool;
    }

    public void setStrap2(bool setBool)
    {
        strap2inPlace = setBool;
    }

    public void setCameraTop(bool setBool)
    {
        camera1inPlace = setBool;
    }

    public void setCameraBottom(bool setBool)
    {
        camera2inPlace = setBool;
    }


    #endregion

    /// <summary>
    /// Getters for booleans, for testing purposes.
    /// </summary>
    #region
    public bool getstrap1inPlace()
    {
        return strap1inPlace;
    }
    public bool getstrap2inPlace()
    {
        return strap2inPlace;
    }
    public bool getsandbag1inPlace()
    {
        return sandbag1inPlace;
    }
    public bool getsandbag2inPlace()
    {
        return sandbag2inPlace;
    }
    public bool getcamera1inPlace()
    {
        return camera1inPlace;
    }
    public bool getcamera2inPlace()
    {
        return camera2inPlace;
    }
    public bool gettableInPLace()
    {
        return tableInPLace;
    }
    public bool getzoomToLevel2()
    {
        return zoomToLevel2;
    }
    public bool getinLevel2()
    {
        return inLevel2;
    }
    public bool getlevelOver()
    {
        return levelOver;
    }
    public bool getdraggingItem()
    {
        return draggingItem;
    }
    #endregion

    /// <summary>
    /// Method called when the level is cleared, used to move to the next stage.
    /// </summary>
    void levelCleared()
    {
        levelOver = true; //Signals to the script that the game has ended
        lvlFM.OnLevelFinished();
    }
}
