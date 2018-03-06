using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBallBehaviour : MonoBehaviour {
	Vector2 startPos, endPos, direction;

	float touchTimeStart, touchTimeFinish, timeInterval;

	[Range (0.05f, 1f)] public float throwForce=0.3f;

	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase==TouchPhase.Began) {
			touchTimeStart=Time.time;
			startPos=Input.GetTouch (0).position;
		}
		if (Input.touchCount > 0 && Input.GetTouch (0).phase==TouchPhase.Ended) {
			touchTimeFinish=Time.time;
			timeInterval=touchTimeFinish - touchTimeStart;
			endPos=Input.GetTouch (0).position;
			direction = startPos - endPos;
			GetComponent<Rigidbody2D>().AddForce (-direction / timeInterval * throwForce);
		}


	}
}

//public class PaperBallBehaviour : MonoBehaviour {
//	public Rigidbody rb;
//	public float force = 2f;
//	public bool isTarget = false;
//	public float zFactor = 2f;
//
//	public Vector3 startPosition;
//
//	private Vector2 startSwipe;
//	private Vector2 endSwipe;
//
//	public GameObject ballObject;
//
//	// Use this for initialization
//	void Start () {
//		startPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
//	}
//
//	// Update is called once per frame
//	void Update () {
//		if (Input.GetMouseButtonDown(0))
//		{
//			startSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
//			Debug.Log("Starting swipe");
//		}
//
//		if (Input.GetMouseButtonUp(0))
//		{
//			endSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
//			if (isTarget)
//			{
//				Swipe();
//				Debug.Log("Ending swipe");
//				isTarget = false;
//			}
//		}
//	}
//
//	void Swipe()
//	{
//		Vector3 swipe = endSwipe - startSwipe;
//		swipe.z = swipe.y / zFactor;
//
//		rb.AddForce(swipe * force, ForceMode.Impulse);
//		Instantiate(ballObject, startPosition, transform.rotation);
//	}
//
//	private void OnMouseDown()
//	{
//		rb.constraints = RigidbodyConstraints.None;
//		isTarget = true;
//	}
//}

//public class PaperBallBehaviour : MonoBehaviour {
//	private Vector3 fp;   //First touch position
//	private Vector3 lp;   //Last touch position
//	private float dragDistance;  //minimum distance for a swipe to be registered
//
//	void Start()
//	{
//		dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
//	}
//
//	void Update()
//	{
//		if (Input.touchCount == 1) // user is touching the screen with a single touch
//		{
//			Touch touch = Input.GetTouch(0); // get the touch
//			if (touch.phase == TouchPhase.Began) //check for the first touch
//			{
//				fp = touch.position;
//				lp = touch.position;
//			}
//			else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
//			{
//				lp = touch.position;
//			}
//			else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
//			{
//				lp = touch.position;  //last touch position. Ommitted if you use list
//
//				//Check if drag distance is greater than 20% of the screen height
//				if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
//				{//It's a drag
//					//check if the drag is vertical or horizontal
//					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
//					{   //If the horizontal movement is greater than the vertical movement...
//						if ((lp.x > fp.x))  //If the movement was to the right)
//						{   //Right swipe
//							Debug.Log("Right Swipe");
//						}
//						else
//						{   //Left swipe
//							Debug.Log("Left Swipe");
//						}
//					}
//					else
//					{   //the vertical movement is greater than the horizontal movement
//						if (lp.y > fp.y)  //If the movement was up
//						{   //Up swipe
//							Debug.Log("Up Swipe");
//						}
//						else
//						{   //Down swipe
//							Debug.Log("Down Swipe");
//						}
//					}
//				}
//				else
//				{   //It's a tap as the drag distance is less than 20% of the screen height
//					Debug.Log("Tap");
//				}
//			}
//		}
//	}
//}


//
//public class PaperBallBehaviour : MonoBehaviour {
//
//	Vector2 swipeStart;
//	Vector2 swipeEnd;
//	int flickTime = 5;
//	int flickLength = 0;
//	float ballVelocity;
//	float ballSpeed = 0;
//	Vector3 worldAngle;
//	GameObject ballPrefab;
//	private bool GetVelocity = false;
//	GameObject[] whoosh;
//	float comfortZone;
//	bool couldbeswipe;
//	float startCountdownLength = 0.0f;
//	bool startTheTimer = false;
//	static bool globalGameStart = false;
//	static bool shootEnable = false;
//	private float startGameTimer = 0.0f;
//
//	void Start () {
//		startTheTimer = true;
//		Time.timeScale = 1;
//		if ( Application.isEditor )
//			Time.fixedDeltaTime = 0.01;
//	}
//
//	void Update () {
//		if (startTheTimer) {
//			startGameTimer += Time.deltaTime;
//		}
//		if (startGameTimer > startCountdownLength){
//			globalGameStart = true;
//			shootEnable = true;
//			startTheTimer = false;
//			startGameTimer = 0;
//		}  
//
//		if (shootEnable) {
//			Debug.Log ("Enabled!");
//			if (Input.touchCount > 0) {
//				var touch = Input.touches[0];
//				switch (touch.phase) {
//				case TouchPhase.Began:
//					flickTime = 5;
//					timeIncrease();
//					couldbeswipe = true;
//					GetVelocity = true;
//					touchStart = touch.position;
//					break;
//				case TouchPhase.Moved:
//					if (Mathf.Abs(touch.position.y - touchStart.y) < comfortZone) {
//						couldbeswipe = false;
//					}
//					else {
//						couldbeswipe = true;
//					}
//				case TouchPhase.Stationary:
//					if (Mathf.Abs(touch.position.y - touchStart.y) < comfortZone) {
//						couldbeswipe = false;
//					}
//					break;
//				case TouchPhase.Ended:
//					var swipeDist = (touch.position - touchStart).magnitude;
//					if (swipeDist > comfortZone) {
//						GetVelocity = false;
//						touchEnd = touch.position;
//						var ball = Instantiate(ballPrefab, Vector3(0,2.6,-11), Quaternion.identity) as GameObject;
//						GetSpeed();
//						GetAngle();
//						ball.rigidbody.AddForce(Vector3((worldAngle.x * ballSpeed), (worldAngle.y * ballSpeed), (worldAngle.z * ballSpeed)));
//						PlayWhoosh();
//
//					}
//				}
//				if (GetVelocity) {
//					flickTime++;
//				}
//			}
//		}
//		if (!shootEnable){
//			Debug.Log("Shot disabled!");
//		}
//	}
//
//	void timeIncrease() {
//		if (GetVelocity) {
//			flickTime++;
//		}
//	}
//
//	void GetSpeed() {
//		flickLength = 90;
//		if (flickTime > 0) {
//			ballVelocity = flickLength / (flickLength - flickTime);
//		}
//		ballSpeed = ballVelocity * 30;
//		ballSpeed = ballSpeed - (ballSpeed * 1.65);
//		if (ballSpeed <= -33){
//			ballSpeed = -33;
//		}
//		Debug.Log("flick was" + flickTime);
//		flickTime = 5;
//	}
//
//	void GetAngle () {
//		worldAngle = camera.ScreenToWorldPoint(Vector3 (touchEnd.x, touchEnd.y + 800, ((camera.nearClipPlane - 100)*1.8)));
//	}
//
//	void PlayWhoosh(){
//		var sound = Instantiate(whoosh[Random.Range(0,whoosh.length)],transform.position,transform.rotation) as GameObject;
//		Debug.Log("Whoosh!");
//	}
//
//}