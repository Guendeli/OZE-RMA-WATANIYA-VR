using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour {


    // Interactive Object Base Class
    public UnityEvent onInteraction;

	// Use this for initialization
    public virtual void OnInteraction()
    {
        onInteraction.Invoke();
    }

    public void DebugInteraction()
    {
        // just a fucking test
        MeshRenderer rend = gameObject.GetComponent<MeshRenderer>();
        if (rend != null)
        {
            rend.enabled = false;
        }
    }
}
