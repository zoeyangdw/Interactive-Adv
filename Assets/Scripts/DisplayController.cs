using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DisplayController : MonoBehaviour {

	private static DisplayController _instance;
	
	public static DisplayController GetInstance()
	{
		if(!_instance){
			_instance = (DisplayController)GameObject.FindObjectOfType(typeof(DisplayController));
		}
		return _instance;
	}

	public void DisplayScene(Scene s){
		StopScene (s);
		GetSceneObject.GetInstance ().ReturnSceneController (s).PlayScene ();
	}

	public void StopScene(Scene s){
		GetSceneObject.GetInstance ().ReturnSceneController (s).StopScene ();
	}

	public void RollbackPresentScene(){

	}

	public void OnSceneChanged4Display(Scene s){
		DisplayScene (s);
	}

	// Use this for initialization
	void Start () {
		StatusController.ChangeScene += OnSceneChanged4Display;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
