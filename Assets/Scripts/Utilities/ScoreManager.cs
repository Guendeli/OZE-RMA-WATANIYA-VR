using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public GameObject winText;
    public GameObject loseText;

	// Use this for initialization
	void Start () {
        SetScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            if (PlayerPrefs.GetInt("Score") == 6)
            {
                winText.SetActive(true);
                loseText.SetActive(false);
            }
            else
            {
                winText.SetActive(false);
                loseText.SetActive(true);
            }
        }
    }
}
