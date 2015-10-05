using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum Scene{
	scenestart = 0,
	sceneWalk = 1,
	sceneHandsPull = 2,
	sceneHandUp = 3,
	sceneHandCircle = 4,
	sceneHandRotate = 5,
	sceneHandHug = 6,
};

public class SceneController : MonoBehaviour {

	private List<AnimComponent> ACManager;

	public void AddAnimObject(AnimComponent a){
		ACManager.Add (a);
	}

	public void PlayScene(){
		for(int i = 0; i < ACManager.Count ; i++){
			ACManager.ElementAt(i).Play();
		}
	}

	public void StopScene(){
		for(int i = 0; i < ACManager.Count ; i++){
			ACManager.ElementAt(i).Stop();
		}
	}

	public bool IsPlayingScene(){
		for(int i = 0; i < ACManager.Count ; i++){
			if(ACManager.ElementAt(i).IsPlaying()){
				return true;
			}
		}
		return false;
	}

	public void Startup(){
		ACManager = new List<AnimComponent> ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
