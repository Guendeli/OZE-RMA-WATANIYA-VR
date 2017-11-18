using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuizElement : MonoBehaviour {

    // Documenting shit

    // this script will be added to UI icons as box collider

    public bool isRightAnswer;   // is this answer right
    public GameObject targetFeedback; // link to particle effect gameobject
    public Transform feedbackPosition; // link to in-scene tranform position

    private Image imageObj;
    private bool _hoverState;
    private bool _isSolved;

    public Sprite correctImg;
    public Sprite wrongImage;

    // helper methods are done here
    void Start()
    {
        imageObj = GetComponent<Image>();
    }
    public void OnInteraction()
    {
        if (_isSolved || !QuizManager.Instance._isGameInit)
        {
            return;
        }
        Debug.Log("Click Bitch");
        // here show the result of the quizz stuff
        _isSolved = true;
        if (isRightAnswer && !QuizManager.Instance._hasGameFinished)
        {
            // TODO: Show win feedback and increment point
            //if (feedbackPosition == null)
            //{
            //    targetFeedback.transform.position = transform.position;
            //}
            //else
            //{
            //    targetFeedback.transform.position = feedbackPosition.position;
            //}
            //targetFeedback.GetComponent<ParticleSystem>().Play();
            imageObj.sprite = correctImg;
            QuizManager.Instance.SetScore(imageObj);
            if (GetComponent<BoxCollider>() != null)
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        }
        else if (!isRightAnswer)
        {
            imageObj.sprite = wrongImage;
            QuizManager.Instance.Punish(imageObj);
            if (GetComponent<BoxCollider>() != null)
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {

        }
    }

    public void OnHoverStart()
    {
        if (_hoverState || !QuizManager.Instance._isGameInit)
        {
            return;
        }
        // play animation
        GetComponent<Outline>().enabled = true;
        _hoverState = true;
        Debug.Log("Hover Enter");
    }

    public void OnHoverExit()
    {     
        // play animation
        GetComponent<Outline>().enabled = false;
        _hoverState = false;
        Debug.Log("Hover Ext");
    }

    void FillEvents()
    {
       
    }
}
