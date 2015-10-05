using UnityEngine;
using System.Collections;

public class Gears : AnimComponent {

	private static Gears _instance;
	
	public static Gears GetInstance()
	{
		if(!_instance){
			_instance = (Gears)GameObject.FindObjectOfType(typeof(Gears));
		}
		return _instance;
	}
}
