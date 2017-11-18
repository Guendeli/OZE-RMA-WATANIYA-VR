using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour {


    // Interactive Object Base Class
    public UnityEvent onInteraction;
    public UnityEvent onHoverStart;
    public UnityEvent onHoverExit;

	// Use this for initialization
    public void OnInteraction()
    {
        onInteraction.Invoke();
    }

    public void OnHoverStart()
    {
        if (onHoverStart != null)
        {
            onHoverStart.Invoke();
        }
    }

    public void OnHoverExit()
    {
        if (onHoverExit != null)
        {
            onHoverExit.Invoke();
        }
    }

}
