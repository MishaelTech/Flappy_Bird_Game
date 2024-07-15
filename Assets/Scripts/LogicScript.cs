using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highText;
    public GameObject gameOverScreen;
    public AudioSource ding;
    public AudioSource over;
    public Health health;
    public BirdScript bird;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    { 
        playerScore = playerScore + scoreToAdd;
        scoreText.text = $"Score: {playerScore}";
        ding.Play();
    }

    private void Update()
    {
        if (playerScore > highScore) 
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
        highText.text = $"HighScore: { PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        bird.birdIsAlive = true;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        //over.Play();
    }

    public void addHealth()
    {
        gameOverScreen.SetActive(false);
        health.health += 1;
        Time.timeScale = 1;
        bird.birdIsAlive = true;
    }
}
