using UnityEngine;
using System.Collections;
public class GestureController : MonoBehaviour {

	private static GestureController _instance;
	
	public static GestureController GetInstance(){
		if(!_instance){
			_instance = (GestureController)GameObject.FindObjectOfType(typeof(GestureController));
		}
		return _instance;
	}

	public void GetQueueOfGestures(){
		Scene s = StatusController.GetInstance ().GetPresentScene ();
	}

	public void GetSourceData(){

	}

	public void RecognizeGesture(Scene s){

		if (0 == 0) {
			GetGesture(s);
		}
	}
	/*
	public void GetLeftHandPosition(){
		int x = 0;
		int y = 0;
		LeftHandPosition (x, y);
	}
	*/
	public delegate void OnGestureRecognized(Scene scene1);
	public static event OnGestureRecognized GetGesture;
	/*
	public delegate void OnLeftHandMoving(int x, int y);
	public static event OnLeftHandMoving LeftHandPosition;
	*/
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
