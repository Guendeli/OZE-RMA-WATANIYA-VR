using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherUtil : MonoBehaviour {

    //public members
    public int sceneId;
    public bool useFade;
    public bool autoload;

    //private members
    private Camera _mainCam; // to avoid calling Camera.main get
    private int counter;

	// Use this for initialization
	void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        _mainCam = Camera.main;
        counter = 0;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        if (autoload)
        {
            Invoke("Autoload", 2.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.F))
        {
            SwitchToScene();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
            {
                SwitchToScene();
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
            {
                counter++;
                if (counter >= 4)
                {
                    SwitchToScene();
                }
            }
        }
	}

    // helepr methods are done here

    public void SwitchToScene()
    {
        if (useFade)
        {
            StartCoroutine(FadeLoadRoutine());
        }
        else
        {
            SceneManager.LoadSceneAsync(sceneId);
        }
    }

    IEnumerator FadeLoadRoutine()
    {
        //Start animation
        _mainCam.GetComponent<FadeInImageEffect>().FadeOut(0.5f);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadSceneAsync(sceneId);
    }

    void Autoload()
    {
        SceneManager.LoadSceneAsync(sceneId);
    }

}
