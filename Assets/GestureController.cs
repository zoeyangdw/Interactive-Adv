using UnityEngine;
using System.Collections;

public class GestureController : MonoBehaviour {

	private static GestureController _instance;
	
	public static GestureController GetInstance()
	{
		if(!_instance)
		{
			_instance = (GestureController)GameObject.FindObjectOfType(typeof(GestureController));
		}
		return _instance;
	}

	public void GetQueueOfGestures(){

	}

	public void GetSourceData(){

	}

	public void RecognizeGesture(){
		if (0 == 0) {
			GetGesture();
		}
	}

	public delegate void OnGestureRecognized();
	public static event OnGestureRecognized GetGesture;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
