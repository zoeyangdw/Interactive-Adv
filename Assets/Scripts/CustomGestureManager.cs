using UnityEngine;
using System.Collections;
using Windows.Kinect;
using Microsoft.Kinect.VisualGestureBuilder;
using System.IO;

public class CustomGestureManager : MonoBehaviour 
{
    VisualGestureBuilderDatabase _gestureDatabase;
    VisualGestureBuilderFrameSource _gestureFrameSource;
    VisualGestureBuilderFrameReader _gestureFrameReader;
    KinectSensor _kinect;
    Gesture _salute;
    Gesture _saluteProgress;
    ParticleSystem _ps;

    public GameObject AttachedObject;

    public void SetTrackingId(ulong id)
    {
        //_gestureFrameReader.IsPaused = false;
        _gestureFrameSource.TrackingId = id;
        _gestureFrameReader.FrameArrived += _gestureFrameReader_FrameArrived;
    }

	// Use this for initialization
	void Start () 
    {
        if (AttachedObject != null)
        {
            _ps = AttachedObject.GetComponent<ParticleSystem>();
            _ps.emissionRate = 4;
            _ps.startColor = Color.blue;
        }
        _kinect = KinectSensor.GetDefault();

        _gestureDatabase = VisualGestureBuilderDatabase.Create("Database/salute.gbd");
        _gestureFrameSource = VisualGestureBuilderFrameSource.Create(_kinect, 0);

        foreach (var gesture in _gestureDatabase.AvailableGestures)
        {
            _gestureFrameSource.AddGesture(gesture);

            if (gesture.Name == "salute")
            {
                _salute = gesture;
            }
            if (gesture.Name == "saluteProgress")
            {
                _saluteProgress = gesture;
            }
        }

        _gestureFrameReader = _gestureFrameSource.OpenReader();
        _gestureFrameReader.IsPaused = true;
	}

    void _gestureFrameReader_FrameArrived(object sender, VisualGestureBuilderFrameArrivedEventArgs e)
    {
        VisualGestureBuilderFrameReference frameReference = e.FrameReference;
        using (VisualGestureBuilderFrame frame = frameReference.AcquireFrame())
        {
            if (frame != null && frame.DiscreteGestureResults != null)
            {
                if (AttachedObject == null)
                    return;

                DiscreteGestureResult result = null;

                if (frame.DiscreteGestureResults.Count > 0)
                    result = frame.DiscreteGestureResults[_salute];
                if (result == null)
                    return;

                if (result.Detected == true)
                {
                    var progressResult = frame.ContinuousGestureResults[_saluteProgress];
                    if (AttachedObject != null)
                    {
                        var prog = progressResult.Progress;
                        float scale = 0.5f + prog * 3.0f;
                        AttachedObject.transform.localScale = new Vector3(scale, scale, scale);
                        if (_ps != null)
                        {
                            _ps.emissionRate = 100 * prog;
                            _ps.startColor = Color.red;
                        }
                    }
                }
                else
                {
                    if (_ps != null)
                    {
                        _ps.emissionRate = 4;
                        _ps.startColor = Color.blue;
                    }
                }
            }
        }
    }
}
