using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public int bombScore;
    //public Text bombScoreText;
    public Text timerText;
    public float gameTime = 0.0f;
    public GameObject gameOverScreen;    

    void Update()
    {
        gameTime = gameTime + Time.deltaTime;
        timerText.text = gameTime.ToString("F0"); 
    }

    [ContextMenu("IncreaseScore")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString(); 
    }

    public void addBombScore(int bombScoreToAdd)
    {
        bombScore = bombScore + bombScoreToAdd;
        //bombScoreText.text = bombScore.ToString();
    }
   
    public void mainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu"); 
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }

    public void gameOver()
    {   
        CheckHighScore();
        //Add new bits to total
        PlayerPrefs.SetInt("BitCount",playerScore + PlayerPrefs.GetInt("BitCount",0)); 
        //Destroy(GameObject.FindWithTag("PlayerDog"));
        GameObject.FindWithTag("PlayerDog").GetComponent<DogScript>().DogDie();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Spawner");

        foreach(GameObject go in gos)
        {
            Destroy(go);    
        }            
        StartCoroutine(waiter());        
    }

    IEnumerator waiter()
    {
        //Wait for 1 seconds
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        gameOverScreen.SetActive(true);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    
    void CheckHighScore()
    {
        if(playerScore > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore",playerScore);          
        }
    }
}
