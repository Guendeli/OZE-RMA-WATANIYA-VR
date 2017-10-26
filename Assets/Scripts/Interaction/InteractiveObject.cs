using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour {


    // Interactive Object Base Class
    public UnityEvent onInteraction;

	// Use this for initialization
    public void OnInteraction()
    {
        onInteraction.Invoke();
    }

}
