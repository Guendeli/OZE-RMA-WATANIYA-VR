using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInput : MonoBehaviour {

    // public members here
    public static GazeInput Instance;

    // private members here
    private Transform _camTransform;
    private InteractiveObject _lastObject;
    public LayerMask ignoredLayers;
    public bool flatMode;
	// Use this for initialization

    void Awake()
    {
        Instance = this;
    }
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
        // nothing until game starts
        if (!QuizManager.Instance._hasGameStarted)
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad) && !flatMode)
            {
                QuizManager.Instance.StartRound();
            }
            if (flatMode)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    //QuizManager.Instance.StartRound();
                }
            }
#if UNITY_EDITOR
            if (Input.GetMouseButtonUp(0))
            {
                QuizManager.Instance.StartRound();
            }
#endif
            return;
        }
        // raycast the shit here
        RaycastHit hitInfo;
        if (Physics.Raycast(_camTransform.position, _camTransform.forward, out hitInfo, ignoredLayers))
        {
            InteractiveObject hitObject = hitInfo.collider.GetComponent<InteractiveObject>();

            if (hitObject != null && !QuizManager.Instance._hasGameFinished)
            {
                if (_lastObject != hitObject)
                {
                    _lastObject = hitObject;
                }
                _lastObject.OnHoverStart();
                if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad) || Input.GetMouseButtonUp(0))
                {
                    hitObject.OnInteraction();
                }
            }
            else
            {
                if (_lastObject != null)
                {
                    _lastObject.OnHoverExit();
                    _lastObject = null;
                }
            }
        }
        else
        {
            if (_lastObject != null)
            {
                _lastObject.OnHoverExit();
                _lastObject = null;
            }
        }
        Debug.DrawRay(_camTransform.position, _camTransform.forward, Color.blue);

        if (flatMode)
        {
            
                if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), _camTransform.forward, out hitInfo, ignoredLayers))
                {
                    InteractiveObject hitObject = hitInfo.collider.GetComponent<InteractiveObject>();

                    if (hitObject != null && !QuizManager.Instance._hasGameFinished)
                    {
                        if (_lastObject != hitObject)
                        {
                            _lastObject = hitObject;
                        }
                        _lastObject.OnHoverStart();
                        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad) || Input.GetMouseButtonUp(0))
                        {
                            hitObject.OnInteraction();
                        }
                    }
                    else
                    {
                        if (_lastObject != null)
                        {
                            _lastObject.OnHoverExit();
                            _lastObject = null;
                        }
                    }
                }
                else
                {
                    if (_lastObject != null)
                    {
                        _lastObject.OnHoverExit();
                        _lastObject = null;
                    }
                }
            
        }
	}

    // helper methods are done here

    void Init()
    {
        _camTransform = Camera.main.transform;
    }

}
