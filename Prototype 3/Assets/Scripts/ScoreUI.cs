using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    //Displays UI
    public TextMeshProUGUI scoreDisplay;
    public int scoreNum;

    // Update is called once per frame
    void Update()
    {

        //Displays score text
        scoreDisplay.text = "Score: " + scoreNum;
        //scoreNum++;

    }
}
