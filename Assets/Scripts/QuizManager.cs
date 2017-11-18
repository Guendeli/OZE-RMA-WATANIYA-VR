using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {

    // this manager handles game logic, should be a singleton
    // will handle mostly game timer and points calculations
    public Image[] imagesList;
    public Sprite scoreTexture;
    public float roundTime;
    public GameObject startText;
    public GameObject endText;
    public Slider timerSlider;
    public GameObject UiParent;

    private int _counter;
    private float _timer;
    public bool _isGameInit{get; private set;}

    public bool _hasGameStarted { get; private set; }
    public bool _hasGameFinished { get; private set; }
    

    //public members
    public static QuizManager Instance;


    // private members


	// Use this for initialization
	void Awake () {
        Instance = this;
        _timer = roundTime;
        _isGameInit = false;
        _hasGameStarted = false;
        _hasGameFinished = false;
        // need to make all the UI false for now on

        UiParent.SetActive(false);
	}

    void Start()
    {
        InitGame();
    }
	
	// Update is called once per frame
	void Update () {
        if (_hasGameStarted)
        {
            CheckTimer();
        }
        if (_counter == 3 && !_hasGameFinished)
        {
            EndGame();            
        }
	}

    // helper stuff is done here

    public void SetScore(Image image)
    {
        _counter++;
    }

    public void Punish(Image image)
    {
        _timer -= 10.0f;
    }
    void CheckTimer()
    {
        if (_timer >= 0)
        {
            _timer -= Time.deltaTime;
            // set slider values
            timerSlider.value = _timer / roundTime;
        }
        if (_timer <= 0 && !_hasGameFinished)
        {
            EndGame();
        }
    }

    public void StartRound()
    {
        if (!_isGameInit)
        {
            return;
        }
        // hide the tap to start Canvas stuff and starts the game
        _hasGameStarted = true;
        startText.SetActive(false);
    }

    public void EndGame()
    {
        // TODO LIst: only in first scene
        _hasGameFinished = true;

        // set the score
        if(PlayerPrefs.HasKey("Score")){
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + _counter);
        }
        //endText.SetActive(true);
        Camera.main.GetComponent<SceneSwitcherUtil>().SwitchToScene();
        // swit h to second scene

        // else second scene:
        // show reward object
    }

    public void InitGame()
    {
        StartCoroutine(InitGameRoutine());
    }

    IEnumerator InitGameRoutine()
    {
        UiParent.SetActive(true);
        // Motion Graphics aimation should be done here
        if (!GazeInput.Instance.flatMode)
        {
            UiParent.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(1.0f);
        }
        _isGameInit = true;
    }

    public void FixPos(GameObject obj)
    {
        obj.transform.position = new Vector3(-21.8f, -0.044f, 0);
    }
}
