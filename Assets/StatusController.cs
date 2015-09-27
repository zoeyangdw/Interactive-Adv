using UnityEngine;
using System.Collections;

public class StatusController : MonoBehaviour {

	private static StatusController _instance;
	
	public static StatusController GetInstance()
	{
		if(!_instance)
		{
			_instance = (StatusController)GameObject.FindObjectOfType(typeof(StatusController));
		}
		return _instance;
	}

	public void OnGestureRecognized(){

	}

	public delegate void OnSceneChanged();
	public static event OnSceneChanged ChangeScene;

	// Use this for initialization
	void Start () {
		GestureController.GetGesture += OnGestureRecognized;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
