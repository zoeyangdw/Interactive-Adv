using UnityEngine;
using System.Collections;

public class DisplayController : MonoBehaviour {

	private static DisplayController _instance;
	
	public static DisplayController GetInstance()
	{
		if(!_instance){
			_instance = (DisplayController)GameObject.FindObjectOfType(typeof(DisplayController));
		}
		return _instance;
	}

	public void DisplayScene(){

	}

	public void RollbackPresentScene(){

	}

	public void OnSceneChanged4Display(Scene s){

	}

	public void UpdateFrame(){

	}

	public void AnimStop(){

	}

	// Use this for initialization
	void Start () {
		StatusController.ChangeScene += OnSceneChanged4Display;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
