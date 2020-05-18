using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject loadLevelPanel;
    public int numberOfBricks;
    public Transform[] levels;
    public int currLevelIndex = 0;
    public Ball ball;
    private int totalLvlBricks;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length + GameObject.FindGameObjectsWithTag("last brick").Length;
        totalLvlBricks = numberOfBricks;
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        //check for no lives left and trigger the end of the game
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        else if (changeInLives < 0)
        {
            RestartLevel();
        }

        livesText.text = "Lives: " + lives;
    }

    private void RestartLevel(){

        Destroy(GameObject.FindWithTag("level"));
        Instantiate(levels[currLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = totalLvlBricks;
        gameOver = false;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateNumOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0)
        {
            if (currLevelIndex >= levels.Length - 1)
            {
                GameOver();
            }
            else
            {
                loadLevelPanel.SetActive(true);
                loadLevelPanel.GetComponentInChildren<Text>().text = "Level " + (currLevelIndex +2);
                gameOver = true;
                ball.newLevel();
                Invoke("LoadLevel" , 3f);
            }
        }
    }

    public void LoadLevel()
    {
        Destroy(GameObject.FindWithTag("level"));
        currLevelIndex++;
        Instantiate(levels[currLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length + GameObject.FindGameObjectsWithTag("last brick").Length;
        totalLvlBricks = numberOfBricks;
        gameOver = false;
        loadLevelPanel.SetActive(false);
    }

    void GameOver()
    {
        gameOver = true;
        ball.newLevel();
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
