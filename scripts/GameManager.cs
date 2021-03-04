using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public void EndGame()
    {
        //If lose the level restart
        gameOverUI.SetActive(true);
        Invoke("Restart", 1f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public GameObject completeLevelUI;
    public GameObject zeroCoin;
    public GameObject oneCoin;

    public int collected = 0;

    public void CompleteLevel()
    {
        //When the level's finished, need to check how many coins were taken to display the correct text at the end
        if (collected == 0)
        {
            zeroCoin.SetActive(true);
            oneCoin.SetActive(false);
        } else if (collected == 1)
        {
            zeroCoin.SetActive(false);
            oneCoin.SetActive(true);
        }

        completeLevelUI.SetActive(true);
        Invoke("NextLevel", 1f);
    }



    public GameObject completeGameUI;

    public void NextLevel()
    {
        //if there's still level to be played load them
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            //display the completed gamed text and stop the game
            completeLevelUI.SetActive(false);
            completeGameUI.SetActive(true);
            
            Time.timeScale = 0;
        }
    }

}
