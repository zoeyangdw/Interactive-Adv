using UnityEngine;
using System.Collections;

public class AnimComponent : MonoBehaviour {
	
	public void Play(){
		GetComponent<Animation>().Play ();
	}
	
	public void Stop(){
		GetComponent<Animation>().Stop ();
	}
	
	public bool IsPlaying(){
		return GetComponent<Animation> ().isPlaying;
	}
	
	// Use this for initialization
	void Start () {
		GetComponent<Animation>().Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
