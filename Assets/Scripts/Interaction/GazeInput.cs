using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInput : MonoBehaviour {

    // public members here


    // private members here
    private Transform _camTransform;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
        // raycast the shit here
        RaycastHit hitInfo;
        if (Physics.Raycast(_camTransform.position, _camTransform.forward, out hitInfo))
        {
            InteractiveObject hitObject = hitInfo.collider.GetComponent<InteractiveObject>();
            if (hitObject != null)
            {
                if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
                {
                    hitObject.OnInteraction();
                }
            }
        }
        Debug.DrawRay(_camTransform.position, _camTransform.forward, Color.blue);
	}

    // helper methods are done here

    void Init()
    {
        _camTransform = Camera.main.transform;
    }
}
