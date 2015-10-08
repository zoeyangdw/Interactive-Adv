using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//各种场景的枚举类型

public class StatusController : MonoBehaviour {
	private static StatusController _instance;

	private Scene presentScene;

	private static int timeDown = 100;
	private int timeDownCount;

	private Stack<Scene> sceneStack;

	public static StatusController GetInstance()
	{
		if(!_instance){
			_instance = (StatusController)GameObject.FindObjectOfType(typeof(StatusController));
		}
		return _instance;
	}

	public Scene GetPresentScene(){
		return presentScene;
		}

	public void OnGestureRecognized(Scene s){
		TurnToScene (s);
	}

	public void OnLeftHandMoving(int x, int y){
		
		AnimComponent a = new AnimComponent();
		a.transform.position.x = x;
		a.transform.position.y = y;
        Debug.Log(x,y);

    }

	private void TurnToScene(Scene s){
		if (s != presentScene || s == 0) {
			presentScene = s;
			ChangeScene (s);
			sceneStack.Push (s);
			timeDownCount = timeDown;
		}
	}

	private void Rollback(){
		if (sceneStack.Count != 0) {
			sceneStack.Pop();
			DisplayController.GetInstance().RollbackPresentScene();
			DisplayController.GetInstance().StopScene(presentScene);
				}
		}

	public delegate void OnSceneChanged4Display(Scene s);
	public static event OnSceneChanged4Display ChangeScene;

	// Use this for initialization
	void Start () {
		GestureController.GetGesture += OnGestureRecognized;
		
		GestureController.LeftHandPosition += OnLeftHandMoving;
		
		presentScene = Scene.scenestart;
		timeDown = 100;
		sceneStack = new Stack<Scene>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey ("w")) {
			OnGestureRecognized (Scene.scenestart);
		}
		//GestureController.GetInstance ().RecognizeGesture (presentScene);
		if (GetSceneObject.GetInstance ().ReturnSceneController (presentScene).IsPlayingScene ()) {
			if (timeDownCount > 0) {
				timeDownCount--;
			}
			else {
				timeDownCount = timeDown;
				Rollback();
			}
		}
	}
}
