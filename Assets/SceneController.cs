using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SceneController : MonoBehaviour {

	private List<AnimComponent> ACManager;

	public void AddAnimObject(){
		ACManager.Add (Gears.GetInstance());
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
		bool b;
		for(int i = 0; i < ACManager.Count ; i++){
			if(ACManager.ElementAt(i).IsPlaying()){
				return true;
			}
		}
		return false;
	}

	// Use this for initialization
	void Start () {
		ACManager = new List<AnimComponent> ();
		AddAnimObject ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
