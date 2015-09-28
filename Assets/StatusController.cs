using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//各种场景的枚举类型
public enum Scene{
	scenestart = 0,
	sceneWalk = 1,
	sceneHandsPull = 2,
	sceneHandUp = 3,
	sceneHandCircle = 4,
	sceneHandRotate = 5,
	sceneHandHug = 6,
};
public class StatusController : MonoBehaviour {
	//记录当前场景
	private Scene presentScene;
	//单例
	private static StatusController _instance;
	//倒计时标杆
	static private int timeDown = 100;
	//倒计时器
	private int timeDownCount;
	//场景栈
	private Stack<Scene> sceneStack;
	//单例
	public static StatusController GetInstance()
	{
		if(!_instance){
			_instance = (StatusController)GameObject.FindObjectOfType(typeof(StatusController));
		}
		return _instance;
	}
	//获取当前情境
	public Scene GetPresentScene(){
		return presentScene;
		}
	//GestureController代理实现
	public void OnGestureRecognized(Scene s){
		TurnToScene (s);
	}
	//情境切换
	private void TurnToScene(Scene s){
		presentScene = s;
		ChangeScene (s);
		sceneStack.Push (s);
		}
	//回退情境
	private void Rollback(){
		if (sceneStack.Count != 0) {
			sceneStack.Pop();
			DisplayController.GetInstance().RollbackPresentScene();
				}
		}

	public delegate void OnSceneChanged4Display(Scene s);
	public static event OnSceneChanged4Display ChangeScene;

	// Use this for initialization
	void Start () {
		GestureController.GetGesture += OnGestureRecognized;
		presentScene = Scene.scenestart;
		timeDown = 100;
		sceneStack = new Stack<Scene>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GestureController.GetInstance ().RecognizeGesture (presentScene);
		DisplayController.GetInstance ().UpdateFrame ();
		timeDownCount--;
		if (timeDownCount == 0) {
			timeDownCount = timeDown;
			Rollback();
		}
	}
}
