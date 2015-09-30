using UnityEngine;
using System.Collections;

public class SceneStartController : SceneController {
	void Start(){
		Startup ();
		AddAnimObject (Gears.GetInstance ());
	}
}
