using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizElement : MonoBehaviour {

    public bool isRightAnswer;   // is this answer right

    // helper methods are done here

    public void OnInteraction()
    {
        // here show the result of the quizz stuff
        if (isRightAnswer)
        {
            // TODO: Show win feedback and increment point
            Debug.Log("Right Answer");
        }
        else
        {
            // show wrong feedback
            Debug.Log("Wrong pal !");
        }
    }
}
