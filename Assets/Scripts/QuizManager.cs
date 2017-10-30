using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour {


    // this manager handles game logic, should be a singleton
    // will handle mostly game timer and points calculations


    //public members
    public static QuizManager Instance;


    // private members


	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
