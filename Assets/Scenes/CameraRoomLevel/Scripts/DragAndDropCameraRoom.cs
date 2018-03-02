
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropCameraRoom : MonoBehaviour {
	
	private bool draggingItem = false; //whether the player is currently dragging an item
	private GameObject draggedObject;  //holds a reference to an object being dragged
	private Vector2 touchOffset;  // allows a grabbed object to stick realistically to the player’s touch position (more about this later).
    private string[] tags = { "Strap1", "Strap2", "Sandbag1", "Sandbag2", "Table" };
    private bool strap1inPlace = false;
    private bool strap2inPlace = false;
    private bool sandbag1inPlace = false;
    private bool sandbag2inPlace = false;




    void Start()
    {
        disableTableHitbox();
	}

    void disableTableHitbox()
    {
        GameObject.FindGameObjectWithTag("Table").GetComponent<BoxCollider2D>().enabled = false;
    }

    void enableTableHitbox()
    {
        GameObject.FindGameObjectWithTag("Table").GetComponent<BoxCollider2D>().enabled = true;
    }


    /// <summary>
    /// calls the methods DropItems() and DragOrPickup() when required
    /// checks if the player is currently touching the screen and if 
    /// he is, Drag or pick up the object, otherwise drop the item
    /// </summary>
    void Update()
	{
		if (HasInput)
		{
			DragOrPickUp();
		}
		else
		{
			if (draggingItem)
				DropItem();
		}
	}

	/// <summary>
	/// returns the position of a detected touch/mouse input
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
	/// if an item is being dragged, move it with the input; 
	/// if an object is not being dragged, pick up an object 
	/// that’s being touched.
	/// </summary>
	private void DragOrPickUp()
	{

		var inputPosition = CurrentTouchPosition;

		if (draggingItem)
		{
			draggedObject.transform.position = inputPosition + touchOffset;
            clickIntoPlace();
        }
		else
		{
            if (sandbag1inPlace && sandbag2inPlace && strap1inPlace && strap2inPlace)
            {
                enableTableHitbox();
            }

			RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
			if (touches.Length > 0 )
			{
				var hit = touches[0];

                PickUp(tags, hit, inputPosition);
            }
		}
	}

    void clickIntoPlace()
    {
        if (draggedObject.name.Equals("Table"))
        {
            draggedObject.transform.position = new Vector2(draggedObject.transform.position.x, 0.0f);
        }
        else if
            (draggedObject.name.Equals("Strap1") &&
            draggedObject.transform.position.y < 0.5f && draggedObject.transform.position.y > -0.5f
            && draggedObject.transform.position.x < -3.5f && draggedObject.transform.position.x > -4.5f
            && sandbag1inPlace && sandbag2inPlace)
        {
            DropItem();
            draggedObject.transform.position = new Vector2(-4.0f, 0.0f);
            draggedObject.GetComponent<BoxCollider2D>().enabled = false;
            strap1inPlace = true;
        }
        else if
            (draggedObject.name.Equals("Strap2") &&
            draggedObject.transform.position.y < 0.5f && draggedObject.transform.position.y > -0.5f
            && draggedObject.transform.position.x < 0.5f && draggedObject.transform.position.x > -0.5f
            && sandbag1inPlace && sandbag2inPlace)
        {
            DropItem();
            draggedObject.transform.position = new Vector2(0.0f, 0.0f);
            draggedObject.GetComponent<BoxCollider2D>().enabled = false;
            strap2inPlace = true;
        }
        else if
            (draggedObject.name.Equals("Sandbag1") &&
            draggedObject.transform.position.y < -1.15f && draggedObject.transform.position.y > -2.15f
            && draggedObject.transform.position.x < -1.5f && draggedObject.transform.position.x > -2.5f)
        {
            DropItem();
            draggedObject.transform.position = new Vector2(-2.0f, -1.65f);
            draggedObject.GetComponent<BoxCollider2D>().enabled = false;
            sandbag1inPlace = true;
        }
        else if
           (draggedObject.name.Equals("Sandbag2") &&
           draggedObject.transform.position.y > 1.15f && draggedObject.transform.position.y < 2.15f
           && draggedObject.transform.position.x < -1.5f && draggedObject.transform.position.x > -2.5f)
        {
            DropItem();
            draggedObject.transform.position = new Vector2(-2.0f, 1.65f);
            draggedObject.GetComponent<BoxCollider2D>().enabled = false;
            sandbag2inPlace = true;
        }
    }

    void PickUp(string[] tags, RaycastHit2D hit, Vector2 inputPosition)
    {
        if (hit.transform != null)
        {
            foreach (string tag in tags)
            {
                if (hit.collider.name.Equals(tag))
                {
                    draggedObject = GameObject.FindGameObjectWithTag(tag);
                    Debug.Log("hit = :" + hit.collider.name);
                    draggingItem = true;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                    break;
                }
            }
        }
    }

	/// <summary>
	/// returns true when the player is currently
	/// touching the screen/holding the mouse button
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
	/// releases a picked up item
	/// </summary>
	void DropItem()
	{
		
		draggingItem = false;
		//draggedObject.transform.localScale = new Vector3(1f, 1f, 1f);
	}



}
