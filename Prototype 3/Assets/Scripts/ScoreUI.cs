using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{

    public TextMeshProUGUI scoreDisplay;
    public int scoreNum;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        scoreDisplay.text = "Score: " + scoreNum;
        scoreNum++;

    }
}