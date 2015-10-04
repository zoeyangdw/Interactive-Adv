using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GetSceneObject : MonoBehaviour {
	private static GetSceneObject _instance;
	private List<SceneController> SceneManager;

	public static GetSceneObject GetInstance()
	{
		if(!_instance){
			_instance = (GetSceneObject)GameObject.FindObjectOfType(typeof(GetSceneObject));
		}
		return _instance;
	}

	private void AddAllSC(){
		SceneStartController s1 = (SceneStartController)GameObject.FindObjectOfType(typeof(SceneStartController));
		//s1.AddAnimObject (Gears.GetInstance());
		SceneManager.Add (s1);
	}

	public SceneController ReturnSceneController(Scene s){
		return SceneManager.ElementAt ((int)s);
	}

	// Use this for initialization
	void Start () {
		SceneManager = new List<SceneController>();
		AddAllSC ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
