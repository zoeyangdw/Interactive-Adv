using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class JudgeGesture : MonoBehaviour {

    public GameObject BodySrcManager;
    public JointType TrackedJoint;
    private BodySourceManager bodyManager;
    private Body[] bodies;

    // Use this for initialization
    void Start () {
        if (BodySrcManager == null)
        {
            Debug.Log("Assign Game Object with Body Source Manager");
        }
        else
        {
            bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (bodyManager == null)
        {
            return;
        }
        else
            bodies = bodyManager.GetData();
    }
}
