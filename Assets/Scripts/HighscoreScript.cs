using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour
{
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text =$"HIGHSCORE: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
