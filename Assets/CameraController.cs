using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private static CameraController _instance;
	
	public static CameraController GetInstance()
	{
		if(!_instance)
		{
			_instance = (CameraController)GameObject.FindObjectOfType(typeof(CameraController));
		}
		return _instance;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
